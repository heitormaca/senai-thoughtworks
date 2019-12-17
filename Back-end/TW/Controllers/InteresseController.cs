using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using TW.Models;
using TW.Repositorios;
using TW.Utils;

namespace TW.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();
        Email sendEmail = new Email();
        UsuarioRepositorio urepositorio = new UsuarioRepositorio();

        /// <summary>
        /// Método que lista os interesses do usuário logado.
        /// </summary>
        /// <returns>Retorna a lista dos interesses do usuário logado.</returns>
        [Authorize(Roles = "Comum")]
        [HttpGet("ListInteresses")]
        public async Task<IActionResult> GetListInteresse() //definição do tipo de retorno
        {
            try
            {
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.GetListInteresse(int.Parse(idDoUsuario));
                return Ok(usr);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para Cadastrar o interesse do usuário logado.
        /// </summary>
        /// <param name="interesse">envia o interesse.</param>
        /// <returns>Retorna o interesse do usuário logado.</returns>
        [Authorize(Roles = "Comum")]
        [HttpPost]
        public async Task<IActionResult> PostInteresse(Interesse interesse)
        {
            try
            {
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await urepositorio.Get(int.Parse(idDoUsuario));
                interesse.IdUsuario = usr.IdUsuario;
                var listaInteresse = await repositorio.GetInteresses();
                foreach (var item in listaInteresse)
                {
                    if(interesse.IdUsuario == item.IdUsuario){
                        if (interesse.IdClassificado == item.IdClassificado)
                        {
                            return BadRequest("Você já efetuou interesse nesse classificado");
                        }
                    }
                }
                return Ok(await repositorio.Post(interesse));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }


        /// <summary>
        /// Método que atualiza o status comprador do usuário para true, envia um email para ele e envia outros emails para os não compradores.
        /// </summary>
        /// <param name="id">Envia um id de interesse.</param>
        /// <returns>Retorna nada.</returns>
        [HttpPut("{id}/vender")]
        public async Task<IActionResult> Vender(int id)
        {
            try
            {
                var interesse = await repositorio.GetbyId(id);
                if (interesse == null) return BadRequest("O interesse não foi localizado");
                interesse.Comprador = true;
                interesse.StatusInteresse = false;
                interesse.DataCompra = DateTime.Now;
                string nome = interesse.IdUsuarioNavigation.NomeCompleto;
                string email = interesse.IdUsuarioNavigation.Email;
                string nomeClassificado = interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento;
                string codigoClassificado = interesse.IdClassificadoNavigation.CodigoClassificado.ToString();
                string nsClassificado = interesse.IdClassificadoNavigation.NumeroDeSerie;
                var fileName = Pdf(nome, email, nomeClassificado, codigoClassificado, nsClassificado);
                var titulo = $"Parabéns {interesse.IdUsuarioNavigation.NomeCompleto} você foi selecionado - Você acaba de adquirir {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
                var body = System.IO.File.ReadAllText(@"Comprador.html");
                sendEmail.EnvioEmailComprador(email, titulo, body, fileName);
                var interessesQueFalharam = interesse
                    .IdClassificadoNavigation
                    .Interesse
                    .Where(a => a.IdInteresse != id)
                    .ToList();
                foreach (var item in interessesQueFalharam)
                {
                    item.StatusInteresse = false;
                    string tituloFalha = $"Não foi dessa vez {interesse.IdUsuarioNavigation.NomeCompleto} - CLASSIFICADO ENCERRADO! - {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
                    string bodyFalha = System.IO.File.ReadAllText(@"NaoComprador.html");
                    sendEmail.EnvioEmail(item.IdUsuarioNavigation.Email, tituloFalha, bodyFalha);
                }
                await repositorio.CommitChanges();

                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar o status do interesse para false.
        /// </summary>
        /// <param name="id">Envia um id do interesse.</param>
        /// <returns>Retorna o interesse atualizado.</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusInteresse(int id)
        {
            var interesse = await repositorio.GetbyId(id);
            interesse.StatusInteresse = false;
            await repositorio.Put(interesse);
            return Ok(interesse);
        }
        private string Pdf(string nome, string email, string nomeClassificado, string codigoClassificado, string nsClassificado)
        {
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(@"New Time - Documento de compra" +
                                   $"Nome: " + nome +
                                   $"Email: " + email +
                                   $"Nome do Produto: " + nomeClassificado +
                                   $"Código do Classificado: " + codigoClassificado +
                                   $"Número de série: " + nsClassificado +
                                   $"Assinatura do Comprador ________________________________" +
                                   $"Assinatura da Empresa __________________________________",
                                    new PdfFont(PdfFontFamily.Helvetica, 13f),
                                    new PdfSolidBrush(Color.Black),
                                    new PointF(50, 50));
            var fileName = "Compra.pdf";
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                doc.SaveToStream(fileStream);
            }
            return fileName;
        }
    }
}