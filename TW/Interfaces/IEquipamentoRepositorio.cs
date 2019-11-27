using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Interfaces
{
    public interface IEquipamentoRepositorio
    {
        Task<List<Equipamento>> GetList(string busca, bool ordenacao);
        Task<Equipamento> Get(int id);
        Task<Equipamento> Post(Equipamento equipamento);
        Task<Equipamento> Put(Equipamento equipamento); 
    }
}