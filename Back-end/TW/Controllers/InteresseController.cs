using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("{ListInteresse}")]
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
                return Ok(await repositorio.Post(interesse));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> ListClassInteresse()
        {
            return Ok(await repositorio.Get());
        }

        [HttpPut("{id}/vender")]
        public async Task<IActionResult> Vender(int id)
        {
            try
            {
                // localizar o interesse e retornar erro caso não encontrado
                var interesse = await repositorio.GetbyId(id);

                if (interesse == null) return BadRequest("O interesse não foi localizado");

                // atualizar o status do interesse
                interesse.Comprador = true;
                interesse.StatusInteresse = false;
                interesse.DataCompra = DateTime.Now;

                // criar o pdf
                string nome = interesse.IdUsuarioNavigation.NomeCompleto;
                string email = interesse.IdUsuarioNavigation.Email;
                string nomeClassificado = interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento;
                string codigoClassificado = interesse.IdClassificadoNavigation.CodigoClassificado.ToString();
                string nsClassificado = interesse.IdClassificadoNavigation.NumeroDeSerie;
                var fileName = Pdf(nome, email, nomeClassificado, codigoClassificado, nsClassificado);

                // criar email de "compra efetuada com sucesso"
                var titulo = $"Parabéns {interesse.IdUsuarioNavigation.NomeCompleto} você foi selecionado - Você acaba de adquirir {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
                var body = System.IO.File.ReadAllText(@"Comprador.html");

                // mandar email para comprador avisando da compra
                sendEmail.EnvioEmailComprador(email, titulo, body, fileName);

                // criar o email de "não foi possível comprar"
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

                    // mandar email para quem não conseguiu comprar
                    sendEmail.EnvioEmail(item.IdUsuarioNavigation.Email, titulo, body);
                }

                // atualizar status do classificado e dos interesses que falharam
                await repositorio.CommitChanges();

                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // [HttpPut("email/{id}")]
        // public async Task<IActionResult> PutEmail(int id, Interesse interesse)
        // {
        //     if (id != interesse.IdInteresse)
        //     {
        //         return BadRequest("Interesse não encontrado.");
        //     }
        //     try
        //     {
        //         var temp = interesse.IdClassificado;
        //         interesse.Comprador = true;
        //         var x = await repositorio.Put(interesse);
        //         string titulo = $"Não foi dessa vez {interesse.IdUsuarioNavigation.NomeCompleto} - CLASSIFICADO ENCERRADO! - {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
        //         string body = System.IO.File.ReadAllText(@"NaoComprador.html");
        //         System.Console.WriteLine("Contents of NaoComprador.html = {0}", body);
        //         List<Interesse> lstInteresse = await repositorio.Get();
        //         foreach (var item in lstInteresse)
        //         {
        //             if (item.IdClassificado == temp && item.Comprador == false)
        //             {
        //                 sendEmail.EnvioEmail(item.IdUsuarioNavigation.Email, titulo, body);
        //             }
        //             else if (item.IdClassificado == temp && item.Comprador == true)
        //             {
        //                 body = System.IO.File.ReadAllText(@"Comprador.html");
        //                 titulo = $"Parabéns {interesse.IdUsuarioNavigation.NomeCompleto} você foi selecionado - Você acaba de adquirir {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
        //                 System.Console.WriteLine("Contents of Comprador.html = {0}", body);
        //                 string nome = interesse.IdUsuarioNavigation.NomeCompleto;
        //                 string email = interesse.IdUsuarioNavigation.Email;
        //                 string nomeClassificado = interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento;
        //                 string codigoClassificado = interesse.IdClassificadoNavigation.CodigoClassificado.ToString();
        //                 string nsClassificado = interesse.IdClassificadoNavigation.NumeroDeSerie;
        //                 PdfDocument anexo = Pdf(nome, email, nomeClassificado, codigoClassificado, nsClassificado);
        //                 sendEmail.EnvioEmailComprador(item.IdUsuarioNavigation.Email, titulo, body, anexo);
        //                 // string anexo = @"C:\Users\fic\Desktop\apostila.pdf";
        //             }
        //         }
        //         return Ok(x);
        //     }
        //     catch (DbUpdateConcurrencyException e)
        //     {
        //         var interesseValido = await repositorio.GetbyId(id);
        //         if (interesseValido == null)
        //         {
        //             return NotFound("Interesse não encontrado.");
        //         }
        //         else
        //         {
        //             return StatusCode(500, e);
        //         }
        //     }
        // }

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
                "Nome: " + nome +
                "Email: " + email +
                "Nome do Produto: " + nomeClassificado +
                "Código do Classificado: " + codigoClassificado +
                "Número de série: " + nsClassificado +
                "Assinatura do Comprador ________________________________" +
                "Assinatura da Empresa __________________________________",
                new PdfFont(PdfFontFamily.Helvetica, 13f),
                new PdfSolidBrush(Color.Black),
                new PointF(50, 50));

            var fileName = "filePDF.pdf";

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                doc.SaveToStream(fileStream);
            }

            return fileName;
        }
    }
}