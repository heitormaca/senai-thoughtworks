using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios {
    public class EquipamentoRepositorio : IEquipamentoRepositorio {
        TWContext context = new TWContext ();
        public async Task<List<Equipamento>> GetList (string busca, bool? ordNomeE, bool? ordMarca, bool? ordMem, bool? ordModelo, bool? ordSO, bool? ordPol, bool? ordPeso, bool? ordPvideo, bool? ordProc, bool? ordHd, bool? ordSsd) {
            var query = context
                .Equipamento
                .Where (x => x.StatusEquipamento == true)
                .AsQueryable ();
            if (!string.IsNullOrEmpty (busca)) {
                query = query.Where (a =>
                    a.NomeEquipamento.Contains (busca) ||
                    a.Marca.Contains (busca) ||
                    a.MemoriaRam.Contains (busca) ||
                    a.Modelo.Contains (busca) ||
                    a.SistemaOperacional.Contains (busca) ||
                    a.Polegada.Contains (busca) ||
                    a.Peso.Contains (busca) ||
                    a.PlacaDeVideo.Contains (busca) ||
                    a.Processador.Contains (busca) ||
                    a.Hd.Contains (busca) ||
                    a.Ssd.Contains (busca) ||
                    a.Dimensoes.Contains (busca) ||
                    a.Alimentacao.Contains (busca)
                );
            }

            if (ordNomeE != null)
            {
                if (ordNomeE.Value)
                {
                    query = query.OrderBy (p => p.NomeEquipamento);
                }
                else
                {
                    query = query.OrderByDescending (p => p.NomeEquipamento);
                }
            }

            if (ordMarca != null)
            {
                if (ordMarca.Value)
                {
                    query = query.OrderBy (p => p.Marca);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Marca);
                }
            }
            if (ordMem != null)
            {
                if (ordMem.Value)
                {
                   query = query.OrderBy (p => p.MemoriaRam); 
                }
                else
                {
                    query = query.OrderByDescending (p => p.MemoriaRam);
                }
            }
            if (ordModelo != null)
            {
                if (ordModelo.Value)
                {
                    query = query.OrderBy (p => p.Modelo);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Modelo);
                }
            }
            if (ordSO != null)
            {
                if (ordSO.Value)
                {
                    query = query.OrderBy (p => p.SistemaOperacional);
                }
                else
                {
                    query = query.OrderByDescending (p => p.SistemaOperacional);
                }
            }
            if (ordPol != null)
            {
                if (ordPol.Value)
                {
                    query = query.OrderBy (p => p.Polegada);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Polegada);
                }
            }
            if (ordPeso != null)
            {
                if(ordPeso.Value)
                {
                    query = query.OrderBy (p => p.Peso);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Peso);
                }
            }
            if (ordPvideo != null)
            {
                if(ordPvideo.Value)
                {
                    query = query.OrderBy (p => p.PlacaDeVideo);
                }
            }
            else
            {
                query = query.OrderByDescending (p => p.PlacaDeVideo);
            }
            if (ordProc != null)

            {
                if (ordProc.Value)
                {
                    query = query.OrderBy (p => p.Processador);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Processador);
                }
            }
            if (ordHd != null)
            {
                if (ordHd.Value)
                {
                    query = query.OrderBy (p => p.Hd);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Hd);
                }
            }
            if (ordSsd != null)
            {
                if (ordSsd.Value)
                {
                    query = query.OrderBy (p => p.Ssd);
                }
                else
                {
                    query = query.OrderByDescending (p => p.Ssd);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<Equipamento> Post (Equipamento equipamento) {
            await context.Equipamento.AddAsync (equipamento);
            await context.SaveChangesAsync ();
            return equipamento;
        }
        public async Task<Equipamento> GetId (int id) {
            return await context.Equipamento.FindAsync (id);
        }
        public async Task<Equipamento> Put (Equipamento equipamento) {
            context.Entry (equipamento).State = EntityState.Modified;
            await context.SaveChangesAsync ();
            return equipamento;
        }
    }
}