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
        public async Task<List<Equipamento>> GetList(string busca, bool ordNomeE/*, bool ordMarca, bool ordMem, bool ordModelo, bool ordSO, bool ordPol, bool ordPeso, bool ordPvideo, bool ordProc, bool ordHd, bool ordSsd*/)
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
            if( ordNomeE == true){
                query = query.OrderBy(p =>p.NomeEquipamento);
            }else{
                query = query.OrderByDescending(p =>p.NomeEquipamento);
            }
            // if(ordMarca == true){
            //     query = query.OrderBy(p =>p.Marca);
            // }else{
            //     query = query.OrderByDescending(p =>p.Marca);
            // }
            // if(ordMem == true){
            //     query = query.OrderBy(p =>p.MemoriaRam);
            // }else{
            //     query = query.OrderByDescending(p =>p.MemoriaRam);
            // }
            // if(ordModelo == true){
            //     query = query.OrderBy(p =>p.Modelo);
            // }else{
            //     query = query.OrderByDescending(p =>p.Modelo);
            // }
            // if(ordSO == true){
            //     query = query.OrderBy(p =>p.SistemaOperacional);
            // }else{
            //     query = query.OrderByDescending(p =>p.SistemaOperacional);
            // }
            // if(ordPol == true){
            //     query = query.OrderBy(p =>p.Polegada);
            // }else{
            //     query = query.OrderByDescending(p =>p.Polegada);
            // }
            // if(ordPeso == true){
            //     query = query.OrderBy(p =>p.Peso);
            // }else{
            //     query = query.OrderByDescending(p =>p.Peso);
            // }
            // if(ordPvideo == true){
            //     query = query.OrderBy(p =>p.PlacaDeVideo);
            // }else{
            //     query = query.OrderByDescending(p =>p.PlacaDeVideo);
            // }
            // if(ordProc == true){
            //     query = query.OrderBy(p =>p.Processador);
            // }else{
            //     query = query.OrderByDescending(p =>p.Processador);
            // }
            // if(ordHd == true){
            //     query = query.OrderBy(p =>p.Hd);
            // }else{
            //     query = query.OrderByDescending(p =>p.Hd);
            // }
            // if(ordSsd == true){
            //     query = query.OrderBy(p =>p.Ssd);
            // }else{
            //     query = query.OrderByDescending(p =>p.Ssd);
            // }
            
            return await query.ToListAsync();
        }

        public async Task<Equipamento> Post(Equipamento equipamento)
        {
            await context.Equipamento.AddAsync(equipamento);
            await context.SaveChangesAsync();
            return equipamento;
        }

    }
}