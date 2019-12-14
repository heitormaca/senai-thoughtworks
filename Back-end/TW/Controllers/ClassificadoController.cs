using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TW.Models;
using TW.Repositorios;
using TW.Utils;

namespace TW.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class ClassificadoController : ControllerBase {
        ClassificadoRepositorio repositorio = new ClassificadoRepositorio ();
        UploadImg img = new UploadImg ();

        /// <summary>
        /// Método para buscar a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="marca">Envia uma marca.</param>
        /// <param name="categoria">Envia uma categoria.</param>
        /// <param name="ordenacao">Envia um estado true para ordenar Crescente e false para ordenar decrescente.</param>
        /// <returns>Retorna a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.</returns>
        [HttpGet]
        [Authorize (Roles = "Comum")]
        public async Task<IActionResult> GetHome (string busca, string marca, string categoria, bool ordenacao) {
            return Ok (await repositorio.GetListHome (busca, marca, categoria, ordenacao));
        }

        /// <summary>
        /// Método que lista, busca e ordena Classificados.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="ordNomeE">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordCodClass">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordNumSerie">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para classificados.</returns>
        [HttpGet ("adm")]
        [Authorize (Roles = "Administrador")]
        public async Task<IActionResult> GetAdm (string busca, bool? ordNomeE, bool? ordCodClass, bool? ordNumSerie) {
            return Ok (await repositorio.GetListAdm (busca, ordNomeE, ordCodClass, ordNumSerie));
        }

        /// <summary>
        /// Método para buscar um classificado específico com todas as informações (Equipamento,Imagens).
        /// </summary>
        /// <param name="id">Envia um id.</param>
        /// <returns>Retorna um classificado específico com todas as informações (Equipamento,Imagens).</returns>
        [Authorize]
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProductClassificado (int id) {
            Classificado classificadoRetornado = await repositorio.GetPageProduct (id);
            if (classificadoRetornado == null) {
                return NotFound ("Classificado não encontrado.");
            }
            return Ok (classificadoRetornado);
        }

        /// <summary>
        /// Método para cadastrar um classificado com no mínimo uma imagem.
        /// </summary>
        /// <param name="classificado">Envia uma classificado.</param>
        /// <returns>Retorna o classificado cadastrado.</returns>
        [Authorize (Roles = "Administrador")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> PostClassificado ([FromForm] Classificado classificado) {
            try {
                var files = Request.Form.Files;
                if (files.Count < 1) return BadRequest ("Favor informar ao menos uma imagem.");
                var listaImagens = new List<Imagemclassificado> ();
                foreach (var file in files) {
                    var imagem = img.Upload (file, "Imagens/ClassificadoImagens");
                    listaImagens.Add (new Imagemclassificado () {
                        Imagem = imagem
                    });
                }
                classificado.Imagemclassificado = listaImagens;
                return Ok (await repositorio.Post (classificado));
            } catch (System.Exception e) {
                return StatusCode (500, e);
            }
        }

        /// <summary>
        /// Método para atualizar o status do classificado para false.
        /// </summary>
        /// <param name="id">Envia um id do classificado.</param>
        /// <returns>Retorna a categoria atualizado.</returns>
        [Authorize (Roles = "Administrador")]
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutStatusClassificado (int id) {
            var classificado = await repositorio.GetById (id);
            classificado.StatusClassificado = false;
            await repositorio.Put (classificado);
            return Ok (classificado);
        }
    }
}