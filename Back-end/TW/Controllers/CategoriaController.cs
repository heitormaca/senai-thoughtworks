using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TW.Models;
using TW.Repositorios;

namespace TW.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]

    public class CategoriaController : ControllerBase {
        CategoriaRepositorio repositorio = new CategoriaRepositorio ();

        /// <summary>
        /// Método que lista, busca e ordena categorias.
        /// </summary>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para categorias.</returns>
        [Authorize (Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetListCat (string busca, bool ordenacao) {
            return Ok (await repositorio.GetList (busca, ordenacao));
        }

        /// <summary>
        /// Método que cadastra uma categoria.
        /// </summary>
        /// <param name="categoria">Envia uma categoria.</param>
        /// <returns>Retorna uma categoria cadastrada.</returns>
        [Authorize (Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> PostCat (Categoria categoria) {
            try {
                await repositorio.Post (categoria);
            } catch (System.Exception e) {
                return StatusCode (500, e);
            }
            return Ok (categoria);
        }

        /// <summary>
        /// Método para atualizar o status da categoria para false.
        /// </summary>
        /// <param name="id">Envia um id da categoria.</param>
        /// <returns>Retorna a categoria atualizado.</returns>
        [Authorize (Roles = "Administrador")]
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutStatusCategoria (int id) {
            var categoria = await repositorio.Get(id);
            if (categoria.Equipamento.Count > 0)
            {
                return BadRequest("Não é possível alterar o status de uma categoria quando existem equipamentos nela.");
            }
            else
            {
                categoria.StatusCategoria = false;
                await repositorio.Put(categoria);
                return Ok (categoria);
            }
        }
    }
}