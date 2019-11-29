using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IClassificadoRepositorio
      {
        Task<List<Classificado>> GetL();
        Task<List<Classificado>> GetListHome(string busca, string marca, string categoria, bool ordenacao);
        Task<List<Classificado>> GetListAdm(string busca, bool? ordNomeE, bool? ordCodClass, bool? ordNumSerie);
        Task<Classificado> GetPageProduct(int id);
        Task<Classificado> Post(Classificado classificado);
        Task<Classificado> Put(Classificado classificado);










    }
}