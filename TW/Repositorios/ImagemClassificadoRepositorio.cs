using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TW.Infertaces;
using TW.Models;

namespace TW.Repositorios
{
    public class ImagemClassificadoRepositorio : IImagemClassificado
    {
        TwContext context = new TwContext();

        public async Task<Imagemclassificado> Delete(Imagemclassificado imagemRetornada)
        {
            context.Imagemclassificado.Remove(imagemRetornada);
            await context.SaveChangesAsync();
            return imagemRetornada;
        }

        public async Task<List<Imagemclassificado>> Get()
        {
            return await context.Imagemclassificado.ToListAsync();
        }

        public async Task<Imagemclassificado> Get(int id)
        {
            return await context.Imagemclassificado.FindAsync(id);
        }

        public async Task<int> Post(Imagemclassificado imagem)
        {
           await context.Imagemclassificado.AddAsync(imagem);
           await context.SaveChangesAsync();
           return imagem.IdImagemClassificado;
        }

        public async Task<Imagemclassificado> Put(Imagemclassificado imagem)
        {
            context.Entry(imagem).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return imagem;
        }


        



        



        



        



        

    }
}