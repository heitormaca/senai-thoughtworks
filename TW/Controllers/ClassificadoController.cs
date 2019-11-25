
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // /api/Classificado?busca=tela17&marca=dell&categoria=notebook
        /// <summary>
        /// Método para buscar a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="marca">Envia uma marca.</param>
        /// <param name="categoria">Envia uma categoria.</param>
        /// <returns>Retorna a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.</returns>
        [HttpGet]
        [Authorize(Roles="Comum")]
        public async Task<IActionResult> GetHome(string busca, string marca, string categoria/*, float? preco*/)
        {
            return Ok(await repositorio.Get(busca, marca, categoria/*, preco*/));
        }

        /// <summary>
        /// Método para buscar a lista dos classificados com seus respectivos nomes, imagens e preços.
        /// </summary>
        /// <returns>Retorna a lista dos classificados com seus respectivos nomes, imagens e preços.</returns>
        [Authorize(Roles="Comum")]
        [HttpGet("listHome")]
        public async Task<ActionResult<List<Classificado>>> GetListHome()
        {
            return await repositorio.SemFiltro();
        }

        // [HttpGet]
        // public async Task<ActionResult<List<Classificado>>> Get() //definição do tipo de retorno
        // {
        //     try
        //     {
        //         return await repositorio.Get();
        //         //await vai esperar traser a lista para armazenar em Categoria
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     } 
            
        // }

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

    //    [HttpGet("precoc")]

    //     public async Task<ActionResult<List<Classificado>>> GetFiltroPrecoCres()
    //     {
    //             return await repositorio.FiltroPrecoCres();
    //     }

    //     [HttpGet("precod")]

    //     public async Task<ActionResult<List<Classificado>>> GetFiltroPrecoDecres()
    //     {
    //             return await repositorio.FiltroPrecoDecres();
    //     }

    //     [HttpGet("nomeequipamentoaz")]
    //     public async Task<ActionResult<List<Classificado>>> GetFiltrarNomeEquipamentoAZ()
    //     {
    //         return await repositorio.FiltrarNomeEquipamentoAZ();
    //     }

    //     [HttpGet("nomeequipamentoza")]
    //     public async Task<ActionResult<List<Classificado>>> GetFiltrarNomeEquipamentoZA()
    //     {
    //         return await repositorio.FiltrarNomeEquipamentoZA();
    //     }

    //     [HttpGet("aa/{id}")]
    //     public async Task<ActionResult<Classificado>> GetProdutoClassificado(int id)
    //     {
    //         Classificado classificadoRetornado = await repositorio.ProdutoClassificado(id);
    //         if(classificadoRetornado == null)
    //         {
    //             return NotFound();
    //         }
    //         return classificadoRetornado;
    //     }    

    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<Classificado>> GetAction(int id)
    //     {
    //         Classificado classificadoRetornado = await repositorio.Get(id);
    //         if(classificadoRetornado == null)
    //         {
    //             return NotFound();
    //         }
    //         return classificadoRetornado;
    //     }

        
        // [HttpPost]
        // public async Task<ActionResult<Classificado>> Post(Classificado classificado)
        // {
        //     try
        //     {
        //         await repositorio.Post(classificado);
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     }
        //     return classificado;
        // }

        // [HttpGet ("h/{marca}")]
        // public async Task<ActionResult<List<Classificado>>> GetFilterMarca (string marca) {
        //     return await repositorio.FiltroPorMarca(marca);
        // }


        // [HttpPut("{id}")]
        // public async Task<ActionResult<Classificado>> Put(int id, Classificado classificado)
        // {
        //     if(id != classificado.IdClassificado)
        //     {
        //         return BadRequest();
        //     }
        //     try
        //     {
        //        return await repositorio.Put(classificado);
                
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         var classificadoValida = await repositorio.Get(id);
        //         if(classificadoValida == null)
        //         {
        //             return NotFound();
        //         }else{
        //             throw;
        //         }
        //     }
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Classificado>> Delete(int id)
        // {
        //     Classificado classificadoRetornado = await repositorio.Get(id);
        //     if(classificadoRetornado == null)
        //     {
        //         return NotFound();
        //     }
        //     await repositorio.Delete(classificadoRetornado);
        //     return classificadoRetornado;
        // }
    }
}