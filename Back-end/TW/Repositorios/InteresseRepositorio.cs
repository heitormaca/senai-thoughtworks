using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Infertaces;
using TW.Models;

namespace TW.Repositorios
{
    public class InteresseRepositorio : IInteresseRepositorio
    {
        TWContext context = new TWContext();
        public async Task<List<Interesse>> GetListInteresse(int id)
        {
            List<Interesse> listaInteresse = await context.Interesse.Include(a => a.IdClassificadoNavigation)
                .Include(b => b.IdClassificadoNavigation.IdEquipamentoNavigation)
                .Include(c => c.IdClassificadoNavigation.Imagemclassificado)
                .Where(l => l.IdUsuario == id)
                .Where(x => x.StatusInteresse == true)
                .ToListAsync();
            foreach (var item in listaInteresse)
            {
                item.IdClassificadoNavigation.Interesse = null;
            }
            return listaInteresse;
        }
        public async Task<List<Interesse>> Get()
        {
            return await context.Interesse.Where(x => x.StatusInteresse == true).ToListAsync();
        }
        public async Task<Interesse> GetbyId(int id)
        {
            return await context.Interesse
                .Include(a => a.IdClassificadoNavigation.Interesse)
                    .ThenInclude(a => a.IdUsuarioNavigation)
                .Include(a => a.IdClassificadoNavigation.IdEquipamentoNavigation)
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(a => a.IdInteresse == id);
        }
        public async Task<Interesse> Post(Interesse interesse)
        {
            await context.Interesse.AddAsync(interesse);
            await context.SaveChangesAsync();
            return interesse;
        }
        public async Task<Interesse> Put(Interesse interesse)
        {
            context.Entry(interesse).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return interesse;
        }

        public async Task CommitChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}