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
        TWContext context = new TWContext();
        public async Task<List<Equipamento>> GetList(string busca, bool? ordNomeE, bool? ordMarca, bool? ordMem, bool? ordModelo, bool? ordSO, bool? ordPol, bool? ordPeso, bool? ordPvideo, bool? ordProc, bool? ordHd, bool? ordSsd)
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
            if(ordNomeE == true){
                query = query.OrderBy(p =>p.NomeEquipamento);
            }else if(ordNomeE == false){
                query = query.OrderByDescending(p =>p.NomeEquipamento);
            }else{}
            if(ordMarca == true){
                query = query.OrderBy(p =>p.Marca);
            }else if(ordMarca == false){
                query = query.OrderByDescending(p =>p.Marca);
            }else{}
            if(ordMem == true){
                query = query.OrderBy(p=>p.MemoriaRam);
            }else if(ordMem == false){
                query = query.OrderByDescending(p=>p.MemoriaRam);
            }else{}
            if(ordModelo == true){
                query = query.OrderBy(p =>p.Modelo);
            }else if(ordModelo == false){
                query = query.OrderByDescending(p =>p.Modelo);
            }else{}
            if(ordSO == true){
                query = query.OrderBy(p =>p.SistemaOperacional);
            }else if(ordSO == false){
                query = query.OrderByDescending(p =>p.SistemaOperacional);
            }else{}
            if(ordPol == true){
                query = query.OrderBy(p =>p.Polegada);
            }else if(ordPol == false){
                query = query.OrderByDescending(p =>p.Polegada);
            }else{}
            if(ordPeso == true){
                query = query.OrderBy(p =>p.Peso);
            }else if(ordPeso == false){
                query = query.OrderByDescending(p =>p.Peso);
            }else{}
            if(ordPvideo == true){
                query = query.OrderBy(p =>p.PlacaDeVideo);
            }else if(ordPvideo == false){
                query = query.OrderByDescending(p =>p.PlacaDeVideo);
            }else{}
            if(ordProc == true){
                query = query.OrderBy(p =>p.Processador);
            }else if(ordProc == false){
                query = query.OrderByDescending(p =>p.Processador);
            }else{}
            if(ordHd == true){
                query = query.OrderBy(p =>p.Hd);
            }else if(ordHd == false){
                query = query.OrderByDescending(p =>p.Hd);
            }else{}
            if(ordSsd == true){
                query = query.OrderBy(p =>p.Ssd);
            }else if(ordSsd == false){
                query = query.OrderByDescending(p =>p.Ssd);
            }else{}
            
            return await query.ToListAsync();
        }

        

        public async Task<Equipamento> Post(Equipamento equipamento)
        {
            await context.Equipamento.AddAsync(equipamento);
            await context.SaveChangesAsync();
            return equipamento;
        }

        public async Task<Equipamento> GetId(int id)
        {
            return await context.Equipamento.FindAsync(id);
        }

    }
}