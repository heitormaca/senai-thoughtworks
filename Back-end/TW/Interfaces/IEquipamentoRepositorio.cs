using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces {
    public interface IEquipamentoRepositorio {
        Task<List<Equipamento>> GetList (string busca, bool? ordNomeE, bool? ordMarca, bool? ordMem, bool? ordModelo, bool? ordSO, bool? ordPol, bool? ordPeso, bool? ordPvideo, bool? ordProc, bool? ordHd, bool? ordSsd);
        Task<Equipamento> Post (Equipamento equipamento);
        Task<Equipamento> GetById (int id);
        Task<Equipamento> Put (Equipamento equipamento);
    }
}