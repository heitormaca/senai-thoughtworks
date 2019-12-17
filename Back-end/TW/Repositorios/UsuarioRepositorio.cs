using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;
using TW.Utils;
using TW.ViewModel;

namespace TW.Repositorios {
    public class UsuarioRepositorio : IUsuarioRepositorio {
        TWContext context = new TWContext ();
        EncryptPassword encrypt = new EncryptPassword ();
        public async Task<List<Usuario>> GetList (string busca, bool? ordNomeC, bool? ordNomeU, bool? ordEmail) {
            var query = context
                .Usuario
                .Where(x => x.StatusUsuario == true)
                .AsQueryable ();
            if (!string.IsNullOrEmpty (busca)) {
                query = query.Where (a =>
                    a.NomeCompleto.Contains (busca) ||
                    a.NomeUsuario.Contains (busca) ||
                    a.Email.Contains (busca)
                );
            }
            if (ordNomeC != null)
            {
                if (ordNomeC.Value)
                {
                    query = query.OrderBy (p => p.NomeCompleto);
                }
                else
                {
                    query = query.OrderByDescending (p => p.NomeCompleto);
                }
            }
            if (ordNomeU != null)
            {
                if (ordNomeU.Value)
                {
                    query = query.OrderBy (p => p.NomeUsuario);
                }
                else
                {
                    query = query.OrderByDescending (p => p.NomeCompleto);
                }
            }
            if (ordEmail != null)
            {
                if (ordEmail.Value)
                {
                    query = query.OrderBy (p => p.Email);
                }
                else
                {
                   query = query.OrderByDescending (p => p.Email); 
                }
            }
            return await query.ToListAsync ();
        }
        public async Task<Usuario> Get(int id) {
            return await context.Usuario.FirstOrDefaultAsync(a => a.IdUsuario == id);
        }
        public async Task<List<Usuario>> GetL () {
            return await context.Usuario.Where (x => x.StatusUsuario == true).ToListAsync ();
        }
        public async Task<bool> ValidaEmail (Usuario usuario) {
            Usuario usrRetornado = await context.Usuario.Where (u => u.Email == usuario.Email).FirstOrDefaultAsync ();
            if (usrRetornado != null) {
                return true;
            }
            return false;
        }
        public async Task<Usuario> Post (Usuario usuario) {
            await context.Usuario.AddAsync (usuario);
            await context.SaveChangesAsync ();
            return usuario;
        }
        public async Task<Usuario> Put (Usuario usuario) {
            context.Entry (usuario).State = EntityState.Modified;
            await context.SaveChangesAsync ();
            return usuario;
        }
        public Usuario Verificacao (ForgotPasswordViewModel verificacao) {
            Usuario usuario = context.Usuario.FirstOrDefault (u => u.Email == verificacao.Email && u.NomeCompleto == verificacao.NomeCompleto);
            return usuario;
        }

        public async Task<List<Usuario>> ListEmail()
        {
            List<Usuario> ListEmail = await context.Usuario.ToListAsync();
            return ListEmail;        
        }
    }
}