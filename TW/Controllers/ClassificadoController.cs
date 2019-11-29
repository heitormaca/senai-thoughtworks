
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        /// <param name="ordenacao">Envia um estado true para ordenar Crescente e false para ordenar decrescente.</param>
        /// <returns>Retorna a lista de classificados com seus respectivos nomes, imagens e preços para a barra de busca e para os filtros da home page.</returns>
        [HttpGet]
        [Authorize(Roles="Comum")]
        public async Task<IActionResult> GetHome(string busca, string marca, string categoria, bool ordenacao)
        {
            return Ok(await repositorio.GetListHome(busca, marca, categoria, ordenacao));
        }

        /// <summary>
        /// Método que lista, busca e ordena Classificados.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="ordNomeE">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordCodClass">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordNumSerie">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para classificados.</returns>
        [HttpGet("adm")]
        [Authorize(Roles="Administrador")]
        public async Task<IActionResult> GetAdm(string busca, bool? ordNomeE, bool? ordCodClass, bool? ordNumSerie){
            return Ok(await repositorio.GetListAdm(busca, ordNomeE, ordCodClass, ordNumSerie));
        }

        /// <summary>
        /// Método para buscar um classificado específico com todas as informações (Equipamento,Imagens).
        /// </summary>
        /// <param name="id">Envia um id.</param>
        /// <returns>Retorna um classificado específico com todas as informações (Equipamento,Imagens).</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Classificado>> GetProductClassificado(int id)
        {
            Classificado classificadoRetornado = await repositorio.GetPageProduct(id);
            if(classificadoRetornado == null)
            {
                return NotFound();
            }
            return classificadoRetornado;
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Classificado>> Post([FromForm] Classificado classificado)
        {
            ImagemClassificadoRepositorio imagem = new ImagemClassificadoRepositorio();
            Imagemclassificado imagens = new Imagemclassificado();

                

                var arquivo = Request.Form.Files[0];
                var arquivo2 = Request.Form.Files[1];
                var arquivo3 = Request.Form.Files[2];
                var arquivo4 = Request.Form.Files[3];
            try
            {
               

                
                imagens.ImagemPrincipal = Upload(arquivo, "Imagens/ClassificadoImagens");
                imagens.ImagemSec1 = Upload(arquivo2, "Imagens/ClassificadoImagens");
                imagens.ImagemSec2= Upload(arquivo3, "Imagens/ClassificadoImagens");
                imagens.ImagemSec3 = Upload(arquivo4, "Imagens/ClassificadoImagens");
                classificado.IdImagemClassificado = await imagem.Post(imagens); 

                await repositorio.Post(classificado);
                
                System.Console.WriteLine("         ");
                System.Console.WriteLine("     "+arquivo.Name+"     ");
                System.Console.WriteLine("     "+arquivo2.Name+"     ");
                System.Console.WriteLine("     "+arquivo3.Name+"     ");
                System.Console.WriteLine("     "+arquivo4.Name+"     ");
                System.Console.WriteLine("         ");
                
            }
            catch (System.Exception)
            {
                throw;
            }
            return classificado;
        }
        private string Upload(IFormFile arquivo,string savingFolder){
            
            if(savingFolder == null) {
                savingFolder = Path.Combine("imgUpdated");                
            }

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), savingFolder);

            if (arquivo.Length > 0) {
                var fileName = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream (fullPath, FileMode.Create)) {
                    arquivo.CopyTo(stream);
                }                    
                return fullPath;
            } else {
                return null;
            }    
        }
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
    }
}