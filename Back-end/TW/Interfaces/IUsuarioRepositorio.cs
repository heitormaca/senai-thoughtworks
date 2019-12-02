using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Get(int id);
        Task<List<Usuario>> GetList(string busca, bool? ordNomeC, bool? ordNomeU, bool? ordEmail);
        Task<List<Usuario>> GetL();
        Task<Usuario> Post(Usuario usuario);
        Task<bool> ValidaEmail(Usuario usuario);
        Task<Usuario> Put(Usuario usuario);
    }
}   