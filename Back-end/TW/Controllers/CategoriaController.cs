using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        /// Método que lista, busca e ordena categorias.
        /// </summary>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para categorias.</returns>
        [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetListCat(string busca, bool ordenacao)
        {
            try
            {
                return Ok(await repositorio.GetList(busca, ordenacao));    
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            } 
        }       

        /// <summary>
        /// Método que cadastra uma categoria.
        /// </summary>
        /// <param name="categoria">Envia uma categoria.</param>
        /// <returns>Retorna uma categoria cadastrada.</returns>
        [Authorize(Roles="Administrador")]
        [HttpPost]
        public async Task<IActionResult> PostCat(Categoria categoria)
        {
            try
            {
                await repositorio.Post(categoria);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
            return Ok(categoria);
        }
    }
}