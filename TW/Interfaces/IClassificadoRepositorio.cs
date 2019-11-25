using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IClassificadoRepositorio
      {
        Task<List<Classificado>> Get();
        Task<List<Classificado>> Get(string busca, string marca, string categoria/*, float? preco*/);
        Task<Classificado> Get(int id);
        Task<Classificado> Post(Classificado classificado);
        Task<Classificado> Put(Classificado classificado);
        Task<Classificado> Delete(Classificado classificadoRetornado);
        Task<List<Classificado>> SemFiltro();
        Task<Classificado> ProdutoClassificado(int id);
        // Task<List<Classificado>> StatusClassificadoON(bool StatusClassificadoON);
        // Task<List<Classificado>> StatusClassificadoOFF(bool StatusClassificadoOFF);
        Task<List<Classificado>> FiltroPrecoCres();
        Task<List<Classificado>> FiltroPrecoDecres();
        Task<List<Classificado>> FiltrarNomeEquipamentoAZ();
        Task<List<Classificado>> FiltrarNomeEquipamentoZA();










    }
}