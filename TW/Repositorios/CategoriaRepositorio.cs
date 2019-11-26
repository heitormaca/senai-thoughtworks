using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Infertaces;
using TW.Models;

namespace TW.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        TwContext context = new TwContext();

        public async Task<List<Categoria>> Get(string busca, string ordenacao)
        {
            var query = context
                .Categoria
                .AsQueryable();
                
            if (!string.IsNullOrEmpty(busca)) {
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

            if(ordenacao == true){
                query = query.OrderBy(p => p.Preco);
            }else{
                query = query.OrderByDescending(p => p.Preco);
            }

            if (!string.IsNullOrEmpty(marca)) {
                query = query.Where(a => a.IdEquipamentoNavigation.Marca.Contains(marca));
            }
        public async Task<Categoria> Delete(Categoria categoriaRetornada)
        {
            context.Categoria.Remove(categoriaRetornada);
            await context.SaveChangesAsync();
            return categoriaRetornada;
        }

        public async Task<List<Categoria>> GetList()
        {
            return await context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await context.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Post(Categoria categoria)
        {
            await context.Categoria.AddAsync(categoria);
            await context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return categoria;
        }
    }
}
