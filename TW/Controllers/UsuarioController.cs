using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Models;
using TW.Repositorios;

namespace TW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        // [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get() //definição do tipo de retorno
        {
            try
            {
                return await repositorio.Get();
                //await vai esperar traser a lista para armazenar em Categoria
            }
            catch (System.Exception)
            {
                throw;
            } 
            
        }       
        [Authorize(Roles="Comum")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetAction(int id)
        {
            Usuario usuarioRetornado = await repositorio.Get(id);
            if(usuarioRetornado == null)
            {
                return NotFound();
            }
            return usuarioRetornado;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                await repositorio.Post(usuario);
            }
            catch (System.Exception)
            {
                throw;
            }
            return usuario;
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        {
            if(id != usuario.IdUsuario)
            {
                return BadRequest();
            }
            try
            {
               return await repositorio.Put(usuario);
                
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

        [HttpPut("up")]
        public async Task<ActionResult<Usuario>> UsuarioImagem([FromForm] Usuario usuario){
           
            try{
            var arquivo = Request.Form.Files[0];  
            usuario.ImagemUsuario = Upload(arquivo,"Imagens/UsuarioImagens");
            usuario.Email = Request.Form["email"];
            usuario.Senha = Request.Form["senha"];
            await repositorio.Put(usuario);
            }catch (System.Exception){
                throw;
            }
            return usuario;
        }

        public string Upload (IFormFile arquivo, string savingFolder){
             
            if(savingFolder == null) {
                savingFolder = Path.Combine ("imgUpdated");                
            }

            var pathToSave = Path.Combine (Directory.GetCurrentDirectory (), savingFolder);

            if (arquivo.Length > 0) {
                var fileName = ContentDispositionHeaderValue.Parse (arquivo.ContentDisposition).FileName.Trim ('"');
                var fullPath = Path.Combine (pathToSave, fileName);

                using (var stream = new FileStream (fullPath, FileMode.Create)) {
                    arquivo.CopyTo (stream);
                }                    

                return fullPath;
            } else {
                return null;
            }           
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            Usuario usuarioRetornado = await repositorio.Get(id);
            if(usuarioRetornado == null)
            {
                return NotFound();
            }
            await repositorio.Delete(usuarioRetornado);
            return usuarioRetornado;
        }
    }
}