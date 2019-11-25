using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TW.Interfaces;
using TW.Models;

namespace TW.Repositorios
{
    public class ClassificadoRepositorio : IClassificadoRepositorio
    {
        TwContext context = new TwContext();
        public async Task<Classificado> Delete(Classificado classificadoRetornado)
        {
            context.Classificado.Remove(classificadoRetornado);
            await context.SaveChangesAsync();
            return classificadoRetornado;
        }

        public async Task<List<Classificado>> Get()
        {
            return await context.Classificado.ToListAsync();

        }

        public async Task<List<Classificado>> Get(string busca, string marca, string categoria/*, float? Preco*/)
        {
            var query = context
                .Classificado
                .Include(a => a.IdEquipamentoNavigation)
                .Include(a => a.IdEquipamentoNavigation.IdCategoriaNavigation)
                .Include(a => a.IdImagemClassificadoNavigation)
                .Include(a => a.Interesse)
                .AsQueryable();

            if (!string.IsNullOrEmpty(busca)) {
                query = query.Where(a => 
                    a.IdEquipamentoNavigation.NomeEquipamento.Contains(busca) || 
                    a.IdEquipamentoNavigation.Processador.Contains(busca) ||
                    (a.CodigoClassificado).ToString().Contains(busca) ||
                    a.IdEquipamentoNavigation.Marca.Contains(busca) ||
                    a.IdEquipamentoNavigation.Modelo.Contains(busca) ||
                    a.IdEquipamentoNavigation.SistemaOperacional.Contains(busca) ||
                    a.IdEquipamentoNavigation.Polegada.Contains(busca) ||
                    a.IdEquipamentoNavigation.MemoriaRam.Contains(busca) ||
                    a.IdEquipamentoNavigation.Ssd.Contains(busca) ||
                    a.IdEquipamentoNavigation.Hd.Contains(busca) ||
                    a.IdEquipamentoNavigation.PlacaDeVideo.Contains(busca) ||
                    a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains(busca)
                );
            }

            if (!string.IsNullOrEmpty(marca)) {
                query = query.Where(a => a.IdEquipamentoNavigation.Marca.Contains(marca));
            }
            
            if (!string.IsNullOrEmpty(categoria)) {
                query = query.Where(a => a.IdEquipamentoNavigation.IdCategoriaNavigation.NomeCategoria.Contains(busca));
            }
            // if (!float.IsNullOrEmpty(Preco)){
            //     query = query.Where(a => a.Preco.Contains(Preco));
            // }

            return await query.ToListAsync();
        }

        public async Task<Classificado> Get(int id)
        {
            return await context.Classificado.FindAsync(id);
        }

        public async Task<Classificado> Post(Classificado classificado)
        {
            await context.Classificado.AddAsync(classificado);
            await context.SaveChangesAsync();
            return classificado;
        }

        public async Task<Classificado> Put(Classificado classificado)
        {
            context.Entry(classificado).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return classificado;
        }
    
        public async Task<List<Classificado>> SemFiltro()
        {
            List<Classificado> listaClassificados = await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderByDescending(d => d.IdClassificado)
                                                                              .ToListAsync(); 

            return listaClassificados;
        }

        public async Task<Classificado> ProdutoClassificado(int id)
        {
            Classificado produto = await context.Classificado.Include(a => a.IdImagemClassificadoNavigation)
                                                        .Include(b => b.IdEquipamentoNavigation.IdCategoriaNavigation)
                                                        .Include(c => c.Interesse)
                                                        .Where(x => x.IdClassificado == id)
                                                        .FirstOrDefaultAsync();
            return produto;
        }

        public async Task<List<Classificado>> FiltroPorMarca(string marca)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.Marca == marca)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .ToListAsync();
            return listaClassificados;
        }

        // public async Task<List<Classificado>> StatusClassificadoON(bool StatusClassificadoON )
        // {
        //     List<Classificado> produto = await context.Classificado.Where(a => a.StatusClassificado == StatusClassificadoON)
        //                                                            .Include(b => b.IdEquipamentoNavigation)
        //                                                            .ToListAsync();
        //     return produto;
        // }
        // public async Task<List<Classificado>> StatusClassificadoOFF(bool StatusClassificadoOFF)
        // {
        //     List<Classificado> produto = await context.Classificado.Where(a => a.StatusClassificado == StatusClassificadoOFF)
        //                                                            .Include(b => b.IdEquipamentoNavigation)
        //                                                            .ToListAsync();
        //     return produto;
        // }

        public async Task<List<Classificado>> FiltroPrecoCres()
        {
             List<Classificado> listaPreco= await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                      .OrderBy(d => d.Preco)
                                                                      .ToListAsync();

            return listaPreco;
        }

        public async Task<List<Classificado>> FiltroPrecoDecres()
        {
            List<Classificado> listaPreco= await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                      .OrderByDescending(d => d.Preco)
                                                                      .ToListAsync();

            return listaPreco;
        }

        public async Task<List<Classificado>> FiltrarNomeEquipamentoAZ()
        {
            List<Classificado> listaClassificados = await context.Classificado.Include(a => a.IdEquipamentoNavigation)
                                                                              .OrderBy(c => c.IdEquipamentoNavigation.NomeEquipamento)
                                                                              .ToListAsync();
            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltrarNomeEquipamentoZA()
        {
            List<Classificado> listaClassificados = await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                              .OrderByDescending(d => d.IdEquipamentoNavigation.NomeEquipamento)
                                                                              .ToListAsync();
            return listaClassificados; 
        }

    }
}