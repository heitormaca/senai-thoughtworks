using System.Collections.Generic;
using System.Threading.Tasks;
using TW.Models;

namespace TW.Infertaces
{
    public interface IImagemClassificado
    {
        Task<List<Imagemclassificado>> Get();
        Task<Imagemclassificado> Get(int id);
        Task<int> Post(Imagemclassificado imagem);
        Task<Imagemclassificado> Put(Imagemclassificado imagem);
        Task<Imagemclassificado> Delete(Imagemclassificado imagemRetornada);
    }
}   