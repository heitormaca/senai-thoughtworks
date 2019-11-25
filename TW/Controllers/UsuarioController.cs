using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Models;
using TW.Repositorios;
using System.Linq;
using System.Collections.Generic;
using TW.ViewModel;

namespace TW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        // [Authorize(Roles="Administrador")]
        // [HttpGet]
        // // public async Task<IActionResult> Get() //definição do tipo de retorno
        // public async Task<ActionResult<List<Usuario>>> Get() //definição do tipo de retorno
        // {
        //     try
        //     {
        //         //  return Ok(HttpContext.User.Claims.First(a => a.Type == "id").Value);
        //         return await repositorio.Get();
        //         // await vai esperar trazer a lista para armazenar em Categoria
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     } 
            
        // }       
        // [Authorize(Roles="Comum")]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Usuario>> GetAction(int id)
        // {
        //     Usuario usuarioRetornado = await repositorio.Get(id);
        //     if(usuarioRetornado == null)
        //     {
        //         return NotFound();
        //     }
        //     return usuarioRetornado;
        // }

        /// <summary>
        /// Método para buscar dados do usuário logado.
        /// </summary>
        /// <returns>Retorna os dados do usuário logado.</returns>
        [Authorize]
        [HttpGet("gUser")]
        public async Task<ActionResult<Usuario>> GetUser(){
           
            try{
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.Get(int.Parse(idDoUsuario));
                return usr;
            }catch (System.Exception){
                throw;
            }
        }
        

        /// <summary>
        /// Método para cadastrar usuário comum ou administrador no sistema.
        /// </summary>
        /// <param name="usuario">Envia nome completo, nome de usuário, email e senha.</param>
        /// <returns>Retorna os dados do usuário recém cadastrado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                var listaUser = await repositorio.Get();
                if(listaUser.Count == 0){
                usuario.CategoriaUsuario = false;
                }
                await repositorio.Post(usuario);

            }
            catch (System.Exception)
            {
                throw;
            }
            return usuario;
        }
        
        // [HttpPut("{id}")]
        // public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        // {
        //     if(id != usuario.IdUsuario)
        //     {
        //         return BadRequest();
        //     }
        //     try
        //     {
        //        return await repositorio.Put(usuario);
                
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         var usuarioValido = await repositorio.Get(id);
        //         if(usuarioValido == null)
        //         {
        //             return NotFound();
        //         }else{
        //             throw;
        //         }
        //     }
        // }

    [Authorize]
    [HttpPatch("changePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] PasswordUpdateViewModel model){
        try
        {
            var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
            var usr = await repositorio.Get(int.Parse(idDoUsuario));
            usr.Senha = model.Senha;
            await repositorio.Put(usr);
            return Ok(usr);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [Authorize]
    [HttpPut("pUser")]
    public async Task<ActionResult<Usuario>> PutUser(Usuario PasswordUpdate){

        try{
            var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
            var usr = await repositorio.Get(int.Parse(idDoUsuario));
            await repositorio.Put(usr);
            return usr;
        }catch (System.Exception){
            throw;
        }
    }

    /// <summary>
    /// Método para atualizar a imagem do usuário logado.
    /// </summary>
    /// <returns>Atualiza a imagem do usuário logado.</returns>
    [Authorize]
    [HttpPut("userImage")]
    public async Task<ActionResult<Usuario>> PutUserImage(){

        try{
            var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
            var usr = await repositorio.Get(int.Parse(idDoUsuario));
            var arquivo = Request.Form.Files[0];
            usr.ImagemUsuario = Upload(arquivo,"Imagens/UsuarioImagens");
            await repositorio.Put(usr);
            return usr;
        }catch (System.Exception){
            throw;
        }
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


    // [HttpDelete("{id}")]
    // public async Task<ActionResult<Usuario>> Delete(int id)
    // {
    //     Usuario usuarioRetornado = await repositorio.Get(id);
    //     if(usuarioRetornado == null)
    //     {
    //         return NotFound();
    //     }
    //     await repositorio.Delete(usuarioRetornado);
    //     return usuarioRetornado;
    // }
    }
}