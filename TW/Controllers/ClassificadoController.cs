
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
    public class ClassificadoController : ControllerBase
    {
        ClassificadoRepositorio repositorio = new ClassificadoRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Classificado>>> Get() //definição do tipo de retorno
        {
            try
            {
                return await repositorio.Get();
                //await vai esperar traser a lista para armazenar em Categoria
            }
            catch (System.Exception)
            {
                throw;
            } 
            
        }

    //     [HttpGet("statuson/{0}")]

    //    public async Task<ActionResult<List<Classificado>>> GetStatusClassificadoCres(bool status)
    //    {
    //        try
    //        {
    //            return await repositorio.StatusClassificadoON(status);
    //        }
    //        catch(System.Exception)
    //        {
    //            throw;
    //        }  
    //    }
    //    [HttpGet("statusoff/{1}")]

    //    public async Task<ActionResult<List<Classificado>>> GetStatusClassificadoDecres(bool status)
    //    {
    //        try
    //        {
    //            return await repositorio.StatusClassificadoOFF(status);
    //        }
    //        catch(System.Exception)
    //        {
    //            throw;
    //        }  
    //    }

       [HttpGet("precoc")]

        public async Task<ActionResult<List<Classificado>>> GetFiltroPrecoCres()
        {
                return await repositorio.FiltroPrecoCres();
        }

        [HttpGet("precod")]

        public async Task<ActionResult<List<Classificado>>> GetFiltroPrecoDecres()
        {
                return await repositorio.FiltroPrecoDecres();
        }

        [HttpGet("nomeequipamentoaz")]
        public async Task<ActionResult<List<Classificado>>> GetFiltrarNomeEquipamentoAZ()
        {
            return await repositorio.FiltrarNomeEquipamentoAZ();
        }

        [HttpGet("nomeequipamentoza")]
        public async Task<ActionResult<List<Classificado>>> GetFiltrarNomeEquipamentoZA()
        {
            return await repositorio.FiltrarNomeEquipamentoZA();
        }

        [HttpGet("aa/{id}")]
        public async Task<ActionResult<Classificado>> GetProdutoClassificado(int id)
        {
            Classificado classificadoRetornado = await repositorio.ProdutoClassificado(id);
            if(classificadoRetornado == null)
            {
                return NotFound();
            }
            return classificadoRetornado;
        }    

        [HttpGet("{id}")]
        public async Task<ActionResult<Classificado>> GetAction(int id)
        {
            Classificado classificadoRetornado = await repositorio.Get(id);
            if(classificadoRetornado == null)
            {
                return NotFound();
            }
            return classificadoRetornado;
        }

        [HttpGet("a/{categoria}/{marca}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterCategoriaMarcaCres(int categoria, string marca)
        {
            return await repositorio.FiltroCategoriaMarcaCres(categoria, marca);
        }
        [HttpGet("b/{categoria}/{marca}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterCategoriaMarcaDecres(int categoria, string marca)
        {
            return await repositorio.FiltroCategoriaMarcaDecres(categoria, marca);
        }
        [HttpGet("a/{categoria}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterCategoriaCres(int categoria)
        {
            return await repositorio.FiltroCategoriaCres(categoria);
        }
        [HttpGet("b/{categoria}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterCategoriaDecres(int categoria)
        {
            return await repositorio.FiltroCategoriaDecres(categoria);
        }
        [HttpGet("c/{marca}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterMarcaCres(string marca)
        {
            return await repositorio.FiltroMarcaCres(marca);
        }
        [HttpGet("d/{marca}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterMarcaDecres(string marca)
        {
            return await repositorio.FiltroMarcaDecres(marca);
        }
        [HttpGet("e")]
        public async Task<ActionResult<List<Classificado>>> GetFilterCres()
        {
            return await repositorio.FiltroCres();
        }
        [HttpGet("f")]
        public async Task<ActionResult<List<Classificado>>> GetFilterDecres()
        {
            return await repositorio.FiltroDecres();
        }
        [HttpGet("g")]
        public async Task<ActionResult<List<Classificado>>> GetListIdDecres()
        {
            return await repositorio.SemFiltro();
        }
        
        [HttpPost]
        public async Task<ActionResult<Classificado>> Post(Classificado classificado)
        {
            try
            {
                await repositorio.Post(classificado);
            }
            catch (System.Exception)
            {
                throw;
            }
            return classificado;
        }

        [HttpGet ("h/{marca}")]
        public async Task<ActionResult<List<Classificado>>> GetFilterMarca (string marca) {
            return await repositorio.FiltroPorMarca(marca);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Classificado>> Put(int id, Classificado classificado)
        {
            if(id != classificado.IdClassificado)
            {
                return BadRequest();
            }
            try
            {
               return await repositorio.Put(classificado);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                var classificadoValida = await repositorio.Get(id);
                if(classificadoValida == null)
                {
                    return NotFound();
                }else{
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Classificado>> Delete(int id)
        {
            Classificado classificadoRetornado = await repositorio.Get(id);
            if(classificadoRetornado == null)
            {
                return NotFound();
            }
            await repositorio.Delete(classificadoRetornado);
            return classificadoRetornado;
        }
    }
}