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
        public async Task<Usuario> Delete(Usuario usuarioRetornado)
        {
            context.Usuario.Remove(usuarioRetornado);
            await context.SaveChangesAsync();
            return usuarioRetornado;
        }

        public async Task<List<Usuario>> Get()
        {
            return await context.Usuario.ToListAsync();   
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuario.FindAsync(id);
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