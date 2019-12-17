using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios
{
    public class ClassificadoRepositorio : IClassificadoRepositorio
    {
        TWContext context = new TWContext();

        public async Task<List<Classificado>> GetListHome(string busca, string marca, string categoria, bool ordenacao)
        {
            var query = context
                .Classificado
                .Include(a => a.IdEquipamentoNavigation)
                .Include(a => a.IdEquipamentoNavigation.IdCategoriaNavigation)
                .Include(a => a.Imagemclassificado)
                .Include(a => a.Interesse)
                .Where(x => x.StatusClassificado == true)
                .AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(a => a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains(categoria));
            }
            if (!string.IsNullOrEmpty(busca))
            {
                query = query.Where(a =>
                   a.IdEquipamentoNavigation.NomeEquipamento.Contains(busca) ||
                   a.IdEquipamentoNavigation.Processador.Contains(busca) ||
                   (a.CodigoClassificado).ToString().Contains(busca) ||
                   a.IdEquipamentoNavigation.Marca.Contains(busca) ||
                   a.IdEquipamentoNavigation.Modelo.Contains(busca) ||
                   a.IdEquipamentoNavigation.SistemaOperacional.Contains(busca) ||
                   a.IdEquipamentoNavigation.Polegada.Contains(busca) ||
                   a.IdEquipamentoNavigation.MemoriaRam.Contains(busca) ||
                   a.IdEquipamentoNavigation.Ssd.Contains(busca) ||
                   a.IdEquipamentoNavigation.Hd.Contains(busca) ||
                   a.IdEquipamentoNavigation.PlacaDeVideo.Contains(busca) ||
                   a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains(busca)
                );
            }
            if (ordenacao == true)
            {
                query = query.OrderBy(p => p.Preco);
            }
            else
            {
                query = query.OrderByDescending(p => p.Preco);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(a => a.IdEquipamentoNavigation.Marca.Contains(marca));
            }
            foreach (var item in query)
            {
                item.IdEquipamentoNavigation.IdCategoriaNavigation.Equipamento = null;
            }
            return await query.ToListAsync();
        }

        public async Task<List<Classificado>> GetListAdm(string busca, bool? ordNomeE, bool? ordCodClass, bool? ordNumSerie)
        {
            var query = context
                .Classificado
                .Include(a => a.IdEquipamentoNavigation)
                .Include(b => b.Imagemclassificado)
                .Where(x => x.StatusClassificado == true)
                .AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {
                query = query.Where(a =>
                   a.IdEquipamentoNavigation.NomeEquipamento.Contains(busca) ||
                   a.IdEquipamentoNavigation.Marca.Contains(busca) ||
                   (a.CodigoClassificado).ToString().Contains(busca) ||
                   a.NumeroDeSerie.Contains(busca)
                );
            }

            if (ordNomeE != null)
            {
                if (ordNomeE.Value)
                {
                    query = query.OrderBy(p => p.IdEquipamentoNavigation.NomeEquipamento);
                }
                else
                {
                    query = query.OrderByDescending(p => p.IdEquipamentoNavigation.NomeEquipamento);
                }
            }

            if (ordCodClass != null)
            {
                if (ordCodClass.Value)
                {
                    query = query.OrderBy(p => p.CodigoClassificado);
                }
                else
                {
                    query = query.OrderByDescending(p => p.CodigoClassificado);
                }
            }

            if (ordNumSerie != null)
            {
                if (ordNumSerie.Value)
                {
                    query = query.OrderBy(p => p.NumeroDeSerie);

                }
                else
                {
                    query = query.OrderByDescending(p => p.NumeroDeSerie);

                }
            }

            return await query.ToListAsync();
        }
        public async Task<Classificado> GetPageProduct(int id)
        {
            Classificado produto = await context.Classificado
                .Include(a => a.IdEquipamentoNavigation)
                .Include(a => a.IdEquipamentoNavigation.IdCategoriaNavigation)
                .Include(a => a.Imagemclassificado)
                .Include(a => a.Interesse)
                .Where(a => a.IdClassificado == id)
                .Where(x => x.StatusClassificado == true)
                .FirstOrDefaultAsync();
            return produto;
        }
        public async Task<Classificado> Post(Classificado classificado)
        {
            await context.Classificado.AddAsync(classificado);
            await context.SaveChangesAsync();
            return classificado;
        }
        public async Task<Classificado> Put(Classificado classificado)
        {
            context.Entry(classificado).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return classificado;
        }
        public async Task<Classificado> GetById(int id)
        {
            return await context.Classificado
                .Include(a => a.Interesse)
                .FirstOrDefaultAsync(a => a.IdClassificado == id);
        }
        public async Task<List<Classificado>> GetClassificadoWithInteresse()
        {
            return await context.Classificado
                .Include(a =>a.Interesse)
                .Include(c => c.IdEquipamentoNavigation)
                .Where(b =>b.StatusClassificado == true)
                .Where(a => a.Interesse.Count > 0)
                .ToListAsync();
        }
        public async Task<List<Interesse>> GetInteressesFromClassificado(int classificadoId)
        {
            return await context.Interesse
                .Include(a => a.IdUsuarioNavigation)
                .Where(a => a.IdClassificado == classificadoId)
                .Where(a => a.StatusInteresse == true)
                .ToListAsync();
        }
    }
}