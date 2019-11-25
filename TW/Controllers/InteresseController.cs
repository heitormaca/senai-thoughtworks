using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        InteresseRepositorio repositorio = new InteresseRepositorio();
        UsuarioRepositorio urepositorio = new UsuarioRepositorio();
        Validacoes validacoes = new Validacoes ();

        /// <summary>
        /// Método que traz uma lista de Interesses
        /// </summary>
        /// <returns>Retorna uma lista de Interesses</returns>

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get () //definição do tipo de retorno
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
        /// Método de busca de interesse por ID
        /// </summary>
        /// <param name="id">Recebe o ID especifico do interesse</param>
        /// <returns>Retorna para o usuário o interesse buscado</returns>

        [HttpGet ("{id}")]
        public async Task<ActionResult<Interesse>> GetAction (int id) {
            Interesse interesseRetornado = await repositorio.Get(id);
            if(interesseRetornado == null)
            {
                return NotFound();
            }
            return interesseRetornado;
        }

        [Authorize(Roles="Comum")]
        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(Interesse interesse)
        {
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
        public async Task<ActionResult<Interesse>> Put (int id, Interesse interesse)
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
                var usuarioValido = await repositorio.Get(id);
                if(usuarioValido == null)
                {
                    return NotFound();
                }else{
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
        public async Task<ActionResult<Interesse>> Delete (int id)
        {
            Interesse interesseRetornado = await repositorio.Get(id);
            if(interesseRetornado == null)
            {
                return NotFound();
            }
            await repositorio.Delete(interesseRetornado);
            return interesseRetornado;
        }
    }
}   