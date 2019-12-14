using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios {
    public class ClassificadoRepositorio : IClassificadoRepositorio {
        TWContext context = new TWContext ();

        public async Task<List<Classificado>> GetListHome (string busca, string marca, string categoria, bool ordenacao) {
            var query = context
                .Classificado
                .Include (a => a.IdEquipamentoNavigation)
                .Include (a => a.IdEquipamentoNavigation.IdCategoriaNavigation)
                .Include (a => a.Imagemclassificado)
                .Include (a => a.Interesse)
                .AsQueryable ();

            if (!string.IsNullOrEmpty (categoria)) {
                query = query.Where (a => a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains (categoria));
            }
            if (!string.IsNullOrEmpty (busca)) {
                query = query.Where (a =>
                    a.IdEquipamentoNavigation.NomeEquipamento.Contains (busca) ||
                    a.IdEquipamentoNavigation.Processador.Contains (busca) ||
                    (a.CodigoClassificado).ToString ().Contains (busca) ||
                    a.IdEquipamentoNavigation.Marca.Contains (busca) ||
                    a.IdEquipamentoNavigation.Modelo.Contains (busca) ||
                    a.IdEquipamentoNavigation.SistemaOperacional.Contains (busca) ||
                    a.IdEquipamentoNavigation.Polegada.Contains (busca) ||
                    a.IdEquipamentoNavigation.MemoriaRam.Contains (busca) ||
                    a.IdEquipamentoNavigation.Ssd.Contains (busca) ||
                    a.IdEquipamentoNavigation.Hd.Contains (busca) ||
                    a.IdEquipamentoNavigation.PlacaDeVideo.Contains (busca) ||
                    a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains (busca)
                );
            }
            if (ordenacao == true) {
                query = query.OrderBy (p => p.Preco);
            } else {
                query = query.OrderByDescending (p => p.Preco);
            }
            if (!string.IsNullOrEmpty (marca)) {
                query = query.Where (a => a.IdEquipamentoNavigation.Marca.Contains (marca));
            }
            foreach (var item in query) {
                item.IdEquipamentoNavigation.IdCategoriaNavigation.Equipamento = null;
            }
            return await query.Where (x => x.StatusClassificado == true).ToListAsync ();
        }

        public async Task<List<Classificado>> GetListAdm (string busca, bool? ordNomeE, bool? ordCodClass, bool? ordNumSerie) {
            var query = context
                .Classificado
                .Include (a => a.IdEquipamentoNavigation)
                .Include (b => b.Imagemclassificado)
                .AsQueryable ();
            if (!string.IsNullOrEmpty (busca)) {
                query = query.Where (a =>
                    a.IdEquipamentoNavigation.NomeEquipamento.Contains (busca) ||
                    (a.CodigoClassificado).ToString ().Contains (busca) ||
                    a.NumeroDeSerie.Contains (busca)
                );
            }
            if (ordNomeE == true) {
                query = query.OrderBy (p => p.IdEquipamentoNavigation.NomeEquipamento);
            } else if (ordNomeE == false) {
                query = query.OrderByDescending (p => p.IdEquipamentoNavigation.NomeEquipamento);
            } else { }
            if (ordCodClass == true) {
                query = query.OrderBy (p => p.CodigoClassificado);
            } else if (ordCodClass == false) {
                query = query.OrderByDescending (p => p.CodigoClassificado);
            } else { }
            if (ordNumSerie == true) {
                query = query.OrderBy (p => p.NumeroDeSerie);
            } else if (ordNumSerie == false) {
                query = query.OrderByDescending (p => p.NumeroDeSerie);
            } else { }
            return await query.Where (x => x.StatusClassificado == true).ToListAsync ();
        }
        public async Task<Classificado> GetPageProduct (int id) {
            Classificado produto = await context.Classificado
                .Include (a => a.IdEquipamentoNavigation)
                .Include (a => a.IdEquipamentoNavigation.IdCategoriaNavigation)
                .Include (a => a.Imagemclassificado)
                .Include (a => a.Interesse)
                .Where (a => a.IdClassificado == id)
                .Where (x => x.StatusClassificado == true)
                .FirstOrDefaultAsync ();
            return produto;
        }
        public async Task<Classificado> Post (Classificado classificado) {
            await context.Classificado.AddAsync (classificado);
            await context.SaveChangesAsync ();
            return classificado;
        }
        public async Task<Classificado> Put (Classificado classificado) {
            context.Entry (classificado).State = EntityState.Modified;
            await context.SaveChangesAsync ();
            return classificado;
        }
        public async Task<Classificado> GetById (int id) {
            return await context.Classificado.FindAsync (id);
        }
    }
}