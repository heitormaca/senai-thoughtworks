using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TW.Models;
using TW.Repositorios;
using System.Linq;
using TW.ViewModel;
using System.Text;
using System.Security.Cryptography;
using System;

namespace TW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();    
        

        /// <summary>
        /// Método para listar, buscar e filtrar dados de usuários registrados no sistema.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="ordNomeC">Envia um estado true para ordenar de A-Z e false para Z-A.</param>
        /// <param name="ordNomeU">Envia um estado true para ordenar de A-Z e false para Z-A.</param>
        /// <param name="ordEmail">Envia um estado true para ordenar de A-Z e false para Z-A.</param>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para usuários.</returns>
        [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetDashUser(string busca, bool? ordNomeC, bool? ordNomeU, bool? ordEmail)
        {
            return Ok(await repositorio.GetList(busca, ordNomeC, ordNomeU, ordEmail));
        }
        
        /// <summary>
        /// Método para buscar dados do usuário logado.
        /// </summary>
        /// <returns>Retorna os dados do usuário logado.</returns>
        [Authorize]
        [HttpGet("gUser")]
        public async Task<IActionResult> GetUser(){
           
            try{
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.Get(int.Parse(idDoUsuario));
                return Ok(usr);
            }catch (System.Exception e){
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para atualizar a senha do usuário.
        /// </summary>
        /// <param name="model">Envia a senha que seja ser atualizada.</param>
        /// <returns>Retorna a senha do usuário atualizada.</returns>
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
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPatch("forgotPassword")]
        public async Task<IActionResult> PostForgotPassword([FromBody] ForgotPasswordViewModel verificacao)
        {
            IActionResult response = Unauthorized("Dados inválidos.");
            var user = Autenticacao(verificacao);
            if(user!=null)
            {   
                
                await repositorio.PutNewPassword(user);
                
                
                return Ok(user);
             
                

            }else{
                return response;
            }
        }
        private Usuario Autenticacao(ForgotPasswordViewModel verificacao)
        {
            Usuario usuario = repositorio.Verificacao(verificacao);
            return usuario;
        }

            
        /// <summary>
        /// Método para cadastrar usuário comum ou administrador no sistema.
        /// </summary>
        /// <param name="usuario">Envia nome completo, nome de usuário, email e senha.</param>
        /// <returns>Retorna os dados do usuário recém cadastrado.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostUser(Usuario usuario)
        {
            try
            {
                var listUser = await repositorio.GetL();
                if(listUser.Count == 0)
                {
                    usuario.CategoriaUsuario = false;
                }
                var senhaEncrypt = Encrypt(usuario.Senha);
                usuario.Senha = senhaEncrypt;
                await repositorio.Post(usuario);
            }
            catch (System.Exception e)
            {   
                return StatusCode(500, e);
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Método para atualizar a imagem do usuário logado.
        /// </summary>
        /// <returns>Atualiza a imagem do usuário logado.</returns>
        [Authorize]
        [HttpPut("userImage")]
        public async Task<IActionResult> PutUserImage(){

            try{
                var idDoUsuario = HttpContext.User.Claims.First(a => a.Type == "id").Value;
                var usr = await repositorio.Get(int.Parse(idDoUsuario));
                var arquivo = Request.Form.Files[0];
                usr.ImagemUsuario = Upload(arquivo,"Imagens/UsuarioImagens");
                await repositorio.Put(usr);
                return Ok(usr);
            }catch (System.Exception e){
                return StatusCode(500, e);
            }
        }

        private string Upload(IFormFile arquivo, string savingFolder){
            
            if(savingFolder == null) {
                savingFolder = Path.Combine("imgUpdated");                
            }

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), savingFolder);

            if (arquivo.Length > 0) {
                var fileName = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim ('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                using(var stream = new FileStream(fullPath, FileMode.Create)) {
                    arquivo.CopyTo(stream);
                }                    

                return fullPath;
            } else {
                return null;
            }           
        }
        public static string Encrypt(string encryptString)    
        {    
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);    
            using (Aes encryptor = Aes.Create())    
            {    
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {      
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76      
        });    
                encryptor.Key = pdb.GetBytes(32);    
                encryptor.IV = pdb.GetBytes(16);    
                using (MemoryStream ms = new MemoryStream())    
                {    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))    
                    {    
                        cs.Write(clearBytes, 0, clearBytes.Length);    
                        cs.Close();    
                    }    
                    encryptString = Convert.ToBase64String(ms.ToArray());    
                }    
            }    
            return encryptString;    
        }
    }
}