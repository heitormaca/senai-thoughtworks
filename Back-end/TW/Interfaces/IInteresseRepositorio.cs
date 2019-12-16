using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Infertaces {
    public interface IInteresseRepositorio {

        
        Task<List<Interesse>> GetInteresses ();
        Task<List<Interesse>> Get ();
        Task<Interesse> GetbyId (int id);
        Task<Interesse> Post (Interesse interesse);
        Task<Interesse> Put (Interesse interesse);
        Task<List<Interesse>> GetListInteresse (int id);
        Task CommitChanges();
    }
}