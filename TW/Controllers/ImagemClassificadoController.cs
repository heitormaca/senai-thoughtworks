using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Models;
using TW.Repositorios;

namespace TW.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ImagemClassificadoController : ControllerBase
    {
       
       ImagemClassificadoRepositorio repositorio = new ImagemClassificadoRepositorio();

      //  [HttpGet]
      //  public async Task<ActionResult<List<Imagemclassificado>>> Get()
      //  {
      //    try
      //    {
      //         return await repositorio.Get();
      //    }
      //    catch (System.Exception)
      //    {
      //       throw;
      //    }
      //  }

      //  [HttpGet("{id}")]

      //  public async Task<ActionResult<Imagemclassificado>> GetAction(int id)
      //  {
      //     Imagemclassificado imagemRetornanda = await repositorio.Get(id);
      //     if(imagemRetornanda == null)
      //     {
      //        return NotFound();
      //     }
      //     return imagemRetornanda;
      //  }

       [HttpPost]

       public async Task<ActionResult<Imagemclassificado>> Post(Imagemclassificado imagem)
       {
          try 
          {
             await repositorio.Post(imagem);
          }
          catch (System.Exception)
          {
             throw;
          }
          return imagem;
       }
       


      //  [HttpPut("{id}")]

      //  public async Task<ActionResult<Imagemclassificado>> Put (int id, Imagemclassificado imagem)
      //  {
      //     if(id != imagem.IdImagemClassificado)
      //     {
      //        return BadRequest();
      //     }
      //     try
      //     {
      //        return await repositorio.Put(imagem);
      //     }
      //     catch (DbUpdateConcurrencyException)
      //     {
      //        var imagemValida = await repositorio.Get(id);
      //        if(imagemValida == null)
      //        {
      //           return NotFound();
      //        }else{
      //           throw;
      //        }
      //     }
      //  }

      //  [HttpDelete("{id}")]

      //  public async Task<ActionResult<Imagemclassificado>> Delete(int id)
      //  {
      //     Imagemclassificado imagemRetornada = await repositorio.Get(id);
      //     if(imagemRetornada == null)
      //     {
      //        return NotFound();
      //     }
      //     await repositorio.Delete(imagemRetornada);
      //     return imagemRetornada;
      //  }


 

    }
}