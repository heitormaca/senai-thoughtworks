using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;
using TW.ViewModel;

namespace TW.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        TWContext context = new TWContext();
        public  Usuario Login(LoginViewModel login)
        {
            Usuario usuario =  context.Usuario.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
          
            return  usuario;
        }
    }
}