using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;
using TW.ViewModel;

namespace TW.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TWContext context = new TWContext();
        

        public async Task<List<Usuario>> GetList(string busca, bool? ordNomeC, bool? ordNomeU, bool? ordEmail)
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
            }else if(ordNomeC == false){
                query = query.OrderByDescending(p => p.NomeCompleto);
            }else{}
            if(ordNomeU == true)
            {
                query = query.OrderBy(p => p.NomeUsuario);
            }else if(ordNomeU == false){
                query = query.OrderByDescending(p => p.NomeCompleto);
            }else{}
            if(ordEmail == true)
            {
                query = query.OrderBy(p => p.Email);
            }else if(ordEmail == false){
                query = query.OrderByDescending(p => p.Email);
            }else{}
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
            var senhaEncrypy = Encrypt(usuario.Senha);
            usuario.Senha = senhaEncrypy;
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> PutNewPassword(Usuario usuario)
        {
            string novaSenha = "CIFV@Y#"+usuario.Email.Length.ToString()+"¨&*("+usuario.NomeCompleto.Length.ToString()+"189mN";
            var senhaEncrypy = Encrypt(novaSenha);
            usuario.Senha = senhaEncrypy;
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }

        public Usuario Verificacao(ForgotPasswordViewModel verificacao){
            Usuario usuario = context.Usuario.FirstOrDefault(u => u.Email == verificacao.Email && u.NomeCompleto == verificacao.NomeCompleto);
            return usuario;
        }
        public static string Encrypt(string encryptString)    
        {    
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);    
            using (Aes encryptor = Aes.Create())    
            {    
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {      
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76      
        });    
                encryptor.Key = pdb.GetBytes(32);    
                encryptor.IV = pdb.GetBytes(16);    
                using (MemoryStream ms = new MemoryStream())    
                {    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))    
                    {    
                        cs.Write(clearBytes, 0, clearBytes.Length);    
                        cs.Close();    
                    }    
                    encryptString = Convert.ToBase64String(ms.ToArray());    
                }    
            }    
            return encryptString;    
        }
    }
}