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
    public class EquipamentoController : ControllerBase
    {
        EquipamentoRepositorio repositorio = new EquipamentoRepositorio();
        
        /// <summary>
        /// Método que lista, busca e ordena equipamentos.
        /// </summary>
        /// <param name="busca">Envia um valor para busca.</param>
        /// <param name="ordenacao">Envia um estado true para ordenar de A-Z e falta para Z-A.</param>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para equipamentos.</returns>
        [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetListEqui(string busca, bool ordenacao)
        {
            try
            {
                return Ok(await repositorio.GetList(busca, ordenacao));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para cadastrar equipamentos.
        /// </summary>
        /// <param name="equipamento">Envia um equipamento.</param>
        /// <returns>Retorna o equipamento recém cadastrado.</returns>
        [Authorize(Roles="Administrador")]
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEqui(Equipamento equipamento)
        {
            try
            {
                await repositorio.Post(equipamento);
            }
            catch (System.Exception)
            {
            
                throw;
            }
            return equipamento;
        }

    }
}