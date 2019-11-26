using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Infertaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> GetList();
        Task<Categoria> Get(int id);
        Task<Categoria> Post(Categoria categoria);
        Task<Categoria> Put(Categoria categoria);
        Task<Categoria> Delete(Categoria categoriaRetornada);
    }
}   