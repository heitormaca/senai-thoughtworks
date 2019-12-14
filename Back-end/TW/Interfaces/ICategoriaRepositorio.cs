using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Infertaces {
    public interface ICategoriaRepositorio {
        Task<List<Categoria>> GetList (string busca, bool ordenacao);
        Task<Categoria> Post (Categoria categoria);
        Task<Categoria> Put (Categoria categoria);
        Task<Categoria> Get (int id);
    }
}