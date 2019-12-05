using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        // Processo de login
        private Usuario Autenticacao(LoginViewModel login) {
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