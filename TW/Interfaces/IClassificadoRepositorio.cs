using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IClassificadoRepositorio
      {
        Task<List<Classificado>> Get();
        Task<Classificado> Get(int id);
        Task<Classificado> Post(Classificado classificado);
        Task<Classificado> Put(Classificado classificado);
        Task<Classificado> Delete(Classificado classificadoRetornado);
        Task<List<Classificado>> FiltroCategoriaMarcaCres(int categoria, string marca);
        Task<List<Classificado>> FiltroCategoriaMarcaDecres(int categoria, string marca);
        Task<List<Classificado>> FiltroCategoriaCres(int categoria);
        Task<List<Classificado>> FiltroCategoriaDecres(int categoria);
        Task<List<Classificado>> FiltroMarcaCres(string marca);
        Task<List<Classificado>> FiltroMarcaDecres(string marca);
        Task<List<Classificado>> FiltroCres();
        Task<List<Classificado>> FiltroDecres();
        Task<List<Classificado>> SemFiltro();
        Task<Classificado> ProdutoClassificado(int id);
        Task<List<Classificado>> FiltroPorMarca(string marca);
        // Task<List<Classificado>> StatusClassificadoON(bool StatusClassificadoON);
        // Task<List<Classificado>> StatusClassificadoOFF(bool StatusClassificadoOFF);
        Task<List<Classificado>> FiltroPrecoCres();
        Task<List<Classificado>> FiltroPrecoDecres();
        Task<List<Classificado>> FiltrarNomeEquipamentoAZ();
        Task<List<Classificado>> FiltrarNomeEquipamentoZA();










    }
}