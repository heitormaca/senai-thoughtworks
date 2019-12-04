using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using TW.Models;
using TW.Repositorios;
using TW.Utils;

namespace TW.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    [EnableCors]

    public class InteresseController : ControllerBase {
        InteresseRepositorio repositorio = new InteresseRepositorio();
        Validacoes validacoes = new Validacoes ();

        /// <summary>
        /// Método que traz uma lista de Interesses
        /// </summary>
        /// <returns>Retorna uma lista de Interesses</returns>

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get() //definição do tipo de retorno
        {
            try
            {
                return await repositorio.Get();
                //await vai esperar trazer a lista para armazenar em Categoria
            }
            catch (System.Exception)
            {
                throw;
            } 

        }

        /// <summary>
        /// Método que lista os interesses do usuário logado.
        /// </summary>
        /// <returns>Retorna a lista dos interesses do usuário logado.</returns>
        [Authorize(Roles="Comum")]
        [HttpGet("{ListInteresse}")]
        public async Task<ActionResult<List<Interesse>>> GetListInteresse() //definição do tipo de retorno
        {
            try
            {
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.GetListInteresse(int.Parse(idDoUsuario));

                return usr;
            }
            catch (System.Exception)
            {
                throw;
            } 

        }

        /// <summary>
        /// Método de busca de interesse por ID
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <returns>Retorna para o usuário o interesse buscado</returns>

        [HttpGet("identificador/{id}")]
        public async Task<ActionResult<Interesse>> GetInteresseId(int id) {
            Interesse interesseRetornado = await repositorio.GetbyId(id);
            if(interesseRetornado == null)
            {
                return NotFound();
            }
            return interesseRetornado;
        }

        /// <summary>
        /// Método para Cadastrar o interesse do usuário logado.
        /// </summary>
        /// <param name="interesse">envia o interesse.</param>
        /// <returns>Retorna o interesse do usuário logado.</returns>
        [Authorize(Roles="Comum")]
        [HttpPost]
        public async Task<ActionResult<Interesse>> PostInteresse(Interesse interesse)
        {
            UsuarioRepositorio urepositorio = new UsuarioRepositorio();
            try
            {
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await urepositorio.Get(int.Parse(idDoUsuario));
                interesse.IdUsuario = usr.IdUsuario;
                return await repositorio.Post(interesse);
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        
        /// <summary>
        /// Método de envio de e-mails para os usuários que registraram interesse no classificado
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <param name="interesse">Recebe as informações do interesse que serão alteradas</param>
        /// <returns>Retorna para o usuário o interesse com as informções alteradas e envia os emails para todos os tipos de usuários</returns>
        [HttpPut ("{id}")]
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)
        {
            if(id != interesse.IdInteresse)
            {
                return BadRequest();
            }
            try
            {
               return await repositorio.Put(interesse);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                var usuarioValido = await repositorio.GetbyId(id);
                if(usuarioValido == null)
                {
                    return NotFound();
                }else{
                    throw;
                }
            }
        }
        [HttpPut ("email/{id}")]
        public async Task<ActionResult<Interesse>> PutEmail (int id, Interesse interesse) {

            if (id != interesse.IdInteresse) {
                return BadRequest ();
            }

            try {

                var temp = interesse.IdClassificado;

                interesse.Comprador = true;

                var x = await repositorio.Put (interesse);

                string titulo = $"Não foi dessa vez {interesse.IdUsuarioNavigation.NomeCompleto} - CLASSIFICADO ENCERRADO! - {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
                // Construct the alternate body as HTML.
                
                string body = System.IO.File.ReadAllText (@"NaoComprador.html");

                System.Console.WriteLine ("Contents of NaoComprador.html = {0}", body);

                List<Interesse> lstInteresse = await repositorio.Get ();

                foreach (var item in lstInteresse) {
                    if (item.IdClassificado == temp && item.Comprador == false) {
                        validacoes.EnvioEmailUsers (item.IdUsuarioNavigation.Email, titulo, body);
                    }else if(item.IdClassificado == temp && item.Comprador == true)             
                    {

                        body = System.IO.File.ReadAllText (@"Comprador.html");
                
                        titulo = $"Parabéns {interesse.IdUsuarioNavigation.NomeCompleto} você foi selecionado - Você acaba de adquirir {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";

                        System.Console.WriteLine ("Contents of Comprador.html = {0}", body);

                        string nome = interesse.IdUsuarioNavigation.NomeCompleto;
                        string email = interesse.IdUsuarioNavigation.Email;
                        string nomeClassificado = interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento;
                        string codigoClassificado = interesse.IdClassificadoNavigation.CodigoClassificado.ToString();
                        string nsClassificado = interesse.IdClassificadoNavigation.NumeroDeSerie;

                        PdfDocument anexo = Pdf(nome, email, nomeClassificado, codigoClassificado, nsClassificado);


                        // string anexo = @"C:\Users\fic\Desktop\apostila.pdf";

                        validacoes.EnvioEmail(item.IdUsuarioNavigation.Email, titulo, body, anexo);
                    }
                }

                return x;

            } catch (DbUpdateConcurrencyException) {
                var interesseValido = await repositorio.GetbyId(id);
                if (interesseValido == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }

        }

        private PdfDocument Pdf(string nome, string email, string nomeClassificado, string codigoClassificado, string nsClassificado)
        {
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(@"New Time - Documento de compra"+
                                    "Nome: "+nome+
                                    "Email: "+email+
                                    "Nome do Produto: "+nomeClassificado+
                                    "Código do Classificado: "+codigoClassificado+
                                    "Número de série:"+nsClassificado,
                                    new PdfFont(PdfFontFamily.Helvetica, 13f),
                                    new PdfSolidBrush(Color.Black),
                                    new PointF(50, 50));
                                    doc.SaveToFile("Compra.pdf");
            return doc;
            

            








          
          
            
        }
    }
}   