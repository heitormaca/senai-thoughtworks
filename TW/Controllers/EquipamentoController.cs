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
        /// <param name="ordNomeE">Envia um estado true para ordenar de A-Z ou false para Z-A.</param>
        /// <param name="ordMarca">Envia um estado true para ordenar de A-Z ou false para Z-A.</param>
        /// <param name="ordMem">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordModelo">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordSO">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordPol">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordPeso">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordPvideo">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordProc">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordHd">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <param name="ordSsd">Envia um estado true para ordenar de A-Z ou falta para Z-A.</param>
        /// <returns>Retorna uma lista, uma busca e um tipo de ordenação para equipamentos.</returns>
        [Authorize(Roles="Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetListEqui(string busca, bool? ordNomeE, bool? ordMarca, bool? ordMem, bool? ordModelo ,bool? ordSO, bool? ordPol, bool? ordPeso, bool? ordPvideo, bool? ordProc, bool? ordHd, bool? ordSsd)
        {
            try
            {
                return Ok(await repositorio.GetList(busca, ordNomeE, ordMarca, ordMem, ordModelo, ordSO , ordPol, ordPeso, ordPvideo, ordProc,ordHd, ordSsd));
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