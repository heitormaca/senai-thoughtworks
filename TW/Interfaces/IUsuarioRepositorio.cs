using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task<Usuario> Post(Usuario usuario);
        Task<bool> ValidaEmail(Usuario usuario);
        Task<Usuario> Put(Usuario usuario);
        Task<Usuario> Delete(Usuario usuarioRetornado);
    }
}   