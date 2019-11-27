using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios
{
    public class EquipamentoRepositorio : IEquipamentoRepositorio
    {
        TwContext context = new TwContext();
        public async Task<List<Equipamento>> GetList(string busca, bool ordenacao)
        {
            var query = context
                .Equipamento
                .AsQueryable();
            if (!string.IsNullOrEmpty(busca)){
                query = query.Where(a =>
                    a.NomeEquipamento.Contains(busca) ||
                    a.Marca.Contains(busca) ||
                    a.MemoriaRam.Contains(busca)||
                    a.Modelo.Contains(busca) ||
                    a.SistemaOperacional.Contains(busca)||
                    a.Polegada.Contains(busca) ||
                    a.Peso.Contains(busca)||
                    a.PlacaDeVideo.Contains(busca) ||
                    a.Processador.Contains(busca)||
                    a.Hd.Contains(busca)||
                    a.Ssd.Contains(busca)||
                    a.Dimensoes.Contains(busca)||
                    a.Alimentacao.Contains(busca)
                );
            }
            if(ordenacao == true){
                query = query.OrderBy(p =>p.NomeEquipamento);
            }else{
                query = query.OrderByDescending(p =>p.NomeEquipamento);
            }
            return await query.ToListAsync();
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