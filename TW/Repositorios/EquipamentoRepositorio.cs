using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios
{
    public class EquipamentoRepositorio : IEquipamentoRepositorio
    {
        TwContext context = new TwContext();
        public async Task<Equipamento> Delete(Equipamento equipamentoRetornado)
        {
            context.Equipamento.Remove(equipamentoRetornado);
            await context.SaveChangesAsync();
            return equipamentoRetornado;
        }

        public async Task<List<Equipamento>> Get()
        {
            return await context.Equipamento.ToListAsync();
        }

        public async Task<Equipamento> Get(int id)
        {
            return await context.Equipamento.FindAsync(id);
        }

        public async Task<Equipamento> Post(Equipamento equipamento)
        {
            await context.Equipamento.AddAsync(equipamento);
            await context.SaveChangesAsync();
            return equipamento;
        }

        public async Task<Equipamento> Put(Equipamento equipamento)
        {
            context.Entry(equipamento).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return equipamento;
        }
    }
}