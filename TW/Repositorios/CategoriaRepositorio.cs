using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Infertaces;
using TW.Models;

namespace TW.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        TwContext context = new TwContext();
        public async Task<Categoria> Delete(Categoria categoriaRetornada)
        {
            context.Categoria.Remove(categoriaRetornada);
            await context.SaveChangesAsync();
            return categoriaRetornada;
        }

        public async Task<List<Categoria>> Get()
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
