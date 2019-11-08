using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Models;
using TW.Repositorios;
using TW.Utils;

namespace TW.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    [EnableCors]

    public class InteresseController : ControllerBase {
        InteresseRepositorio repositorio = new InteresseRepositorio ();
        Validacoes validacoes = new Validacoes ();

        /// <summary>
        /// Método que traz uma lista de Interesses
        /// </summary>
        /// <returns>Retorna uma lista de Interesses</returns>

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get () //definição do tipo de retorno
        {
            try {
                List<Interesse> lstInteresse = await repositorio.Get ();

                foreach (var item in lstInteresse) {
                    item.IdClassificadoNavigation.Interesse = null;
                }

                return lstInteresse;
                //await vai esperar traser a lista para armazenar em Categoria
            } catch (System.Exception) {
                throw;
            }

        }

        /// <summary>
        /// Método de busca de interesse por ID
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <returns>Retorna para o usuário o interesse buscado</returns>

        [HttpGet ("{id}")]
        public async Task<ActionResult<Interesse>> GetAction (int id) {
            Interesse interesseRetornado = await repositorio.Get (id);
            if (interesseRetornado == null) {
                return NotFound ();
            }
            return interesseRetornado;  
        }

        [HttpPost]
        public async Task<ActionResult<Interesse>> Post (Interesse interesse) //tipo do objeto que está sendo enviado (Categoria) - nome que você determina pro objeto
        {
            try {
                await repositorio.Post (interesse);
            } catch (System.Exception) {
                throw;
            }
            return interesse;
        }

        /// <summary>
        /// Método de envio de e-mails para os usuários que registraram interesse no classificado
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <param name="interesse">Recebe as informações do interesse que serão alteradas</param>
        /// <returns>Retorna para o usuário o interesse com as informções alteradas e envia os emails para todos os tipos de usuários</returns>

        [HttpPut ("{id}")]
        public async Task<ActionResult<Interesse>> Put (int id, Interesse interesse) {
            if (id != interesse.IdInteresse) {
                return BadRequest ();
            }

            try {

                interesse.Comprador = true;

                var x = await repositorio.Put (interesse);

                string titulo = $"Não foi dessa vez {interesse.IdUsuarioNavigation.NomeCompleto} - CLASSIFICADO ENCERRADO! - {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";
                // Construct the alternate body as HTML.
                
                string body = System.IO.File.ReadAllText (@"NaoComprador.html");

                System.Console.WriteLine ("Contents of NaoComprador.html = {0}", body);

                List<Interesse> lstInteresse = await repositorio.Get ();

                foreach (var item in lstInteresse) {
                    if (item.Comprador == false) {
                        validacoes.EnvioEmailUsers (item.IdUsuarioNavigation.Email, titulo, body);
                    } else {

                        body = System.IO.File.ReadAllText (@"Comprador.html");
                
                        titulo = $"Parabéns {interesse.IdUsuarioNavigation.NomeCompleto} você foi selecionado - Você acaba de adquirir {interesse.IdClassificadoNavigation.IdEquipamentoNavigation.NomeEquipamento}";

                        System.Console.WriteLine ("Contents of Comprador.html = {0}", body);

                        string anexo = @"C:\Users\fic\Desktop\apostila.pdf";

                        validacoes.EnvioEmail (item.IdUsuarioNavigation.Email, titulo, body, anexo);
                    }
                }

                return x;

            } catch (DbUpdateConcurrencyException) {
                var interesseValido = await repositorio.Get (id);
                if (interesseValido == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }
        }

        /// <summary>
        /// Método que deleta um registro de interesse
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <returns>Retorna o interesse especificado</returns>

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Interesse>> Delete (int id) {
            Interesse interesseRetornado = await repositorio.Get (id);
            if (interesseRetornado == null) {
                return NotFound ();
            }
            await repositorio.Delete (interesseRetornado);
            return interesseRetornado;
        }
    }
}