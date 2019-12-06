using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TW.Models;
using TW.Repositorios;
using TW.ViewModel;

namespace TW.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]

    public class LoginController : ControllerBase {
        
 LoginRepositorio loginRepositorio = new LoginRepositorio();
        private IConfiguration configuracao;

        public LoginController(IConfiguration config) {
            configuracao = config;
        }


        // Gerar as tokens de acesso para o usuário

            private string GenerateJSONWebToken(Usuario userInfo){
            var securityKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (configuracao["Jwt:key"]));
            var credentials = new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha256);
            string resposta;
            if(userInfo.CategoriaUsuario == true){
                resposta = "Comum";
            }else{
                resposta = "Administrador";
            }

            var claims = new [] {
                new Claim (JwtRegisteredClaimNames.NameId, userInfo.NomeUsuario),
                new Claim (JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new Claim (ClaimTypes.Role, resposta),
                new Claim ("id", userInfo.IdUsuario.ToString()),
                new Claim ("Role", resposta)
            };

            var token = new JwtSecurityToken (configuracao["Jwt:Issuer"],
                configuracao["Jwt:Issuer"], claims,
                expires : DateTime.Now.AddMinutes (120),
                signingCredentials : credentials);

            return new JwtSecurityTokenHandler ().WriteToken (token);
        }
        //Método de criptografia
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
        // Processo de login
        private Usuario Autenticacao(LoginViewModel login) {
            var senhaEncrypt = Encrypt(login.Senha);
            login.Senha = senhaEncrypt;
            Usuario usuario = loginRepositorio.Login(login);
            return usuario;
        }

        /// <summary>
        /// Método de logar no sistema.
        /// </summary>
        /// <param name="login">Envia o email e a senha.</param>
        /// <returns>Retorna o token de acesso.</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostLogin([FromBody] LoginViewModel login) {
            IActionResult response = Unauthorized();
            var user = Autenticacao (login);

            if (user != null) {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok (new { token = tokenString });
            }
            return response;
        }
    }
}