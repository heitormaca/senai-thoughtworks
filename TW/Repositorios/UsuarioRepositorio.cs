using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TwContext context = new TwContext();
        

        public async Task<List<Usuario>> GetList(string busca, bool ordNomeC, bool ordNomeU, bool ordEmail)
        {
            var query = context
                .Usuario
                .AsQueryable();
            if(!string.IsNullOrEmpty(busca))
            {
                query = query.Where(a => 
                a.NomeCompleto.Contains(busca) ||
                a.NomeUsuario.Contains(busca) ||
                a.Email.Contains(busca)
                );
            }
            if(ordNomeC == true)
            {
                query = query.OrderBy(p => p.NomeCompleto);
            }else{
                query = query.OrderByDescending(p => p.NomeCompleto);
            }
            if(ordNomeU == true)
            {
                query = query.OrderBy(p => p.NomeUsuario);
            }else{
                query = query.OrderByDescending(p => p.NomeCompleto);
            }
            if(ordEmail == true)
            {
                query = query.OrderBy(p => p.Email);
            }else{
                query = query.OrderByDescending(p => p.Email);
            }
            

            return await query.ToListAsync();   
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuario.FindAsync(id);
        }
        public async Task<List<Usuario>> GetL()
        {
            return await context.Usuario.ToListAsync();
        }
        public async Task<bool> ValidaEmail(Usuario usuario)
        {
            Usuario usrRetornado = await context.Usuario.Where(u => u.Email == usuario.Email).FirstOrDefaultAsync();

            if(usrRetornado != null)
            {
                 return true;
            }
            return false;
        }

        public async Task<Usuario> Post(Usuario usuario)
        {
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> Put(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Salvar(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }
    }
}