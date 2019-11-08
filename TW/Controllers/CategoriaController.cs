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

    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();

        
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                return await repositorio.Get();
               
            }
            catch (System.Exception)
            {
                throw;
            } 
            
        }       

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetAction(int id)
        {
            Categoria categoriaRetornada = await repositorio.Get(id);
            if(categoriaRetornada == null)
            {
                return NotFound();
            }
            return categoriaRetornada;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria) //tipo do objeto que está sendo enviado (Categoria) - nome que você determina pro objeto
        {
            try
            {
                await repositorio.Post(categoria);
            }
            catch (System.Exception)
            {
                throw;
            }
            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if(id != categoria.IdCategoria)
            {
                return BadRequest();
            }
            try
            {
               return await repositorio.Put(categoria);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                var categoriaValida = await repositorio.Get(id);
                if(categoriaValida == null)
                {
                    return NotFound();
                }else{
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            Categoria categoriaRetornada = await repositorio.Get(id);
            if(categoriaRetornada == null)
            {
                return NotFound();
            }
            await repositorio.Delete(categoriaRetornada);
            return categoriaRetornada;
        }
    }
}