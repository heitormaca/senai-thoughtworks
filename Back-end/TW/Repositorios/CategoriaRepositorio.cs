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
        TWContext context = new TWContext();
        public async Task<List<Categoria>> GetList(string busca, bool ordenacao)
        {
            var query = context
                .Categoria
                .AsQueryable();  
            if (!string.IsNullOrEmpty(busca)) 
            {
                query = query.Where(a => 
                    a.NomeCategoria.Contains(busca)
                );
            }
            if(ordenacao == true)
            {
                query = query.OrderBy(p => p.NomeCategoria);
            }
            else
            {
                query = query.OrderByDescending(p => p.NomeCategoria);
            }
            return await query.ToListAsync();
        }
        public async Task<Categoria> Post(Categoria categoria)
        {
            await context.Categoria.AddAsync(categoria);
            await context.SaveChangesAsync();
            return categoria;
        }
    }
}
