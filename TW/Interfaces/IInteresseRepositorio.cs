using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Infertaces
{
    public interface IInteresseRepositorio
    {
        Task<List<Interesse>> Get();
        Task<Interesse> Get(int id);
        Task<Interesse> Post(Interesse interesse);
        Task<Interesse> Put(Interesse interesse);
        Task<Interesse> Delete(Interesse interesseRetornado);
    }
}   