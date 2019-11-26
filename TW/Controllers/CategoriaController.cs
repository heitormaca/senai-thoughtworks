using System.Collections.Generic;
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

    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();


        /// <summary>
        /// Método que lista todas as categorias cadastradas.
        /// </summary>
        /// <returns>Retorna a lista de todas categorias cadastradas.</returns>
        [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetListCat()
        {
            try
            {
                return await repositorio.GetList();
            
            }
            catch (System.Exception)
            {
                throw;
            } 
        
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
    }
}