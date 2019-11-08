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

        public async Task<List<Classificado>> FiltroCategoriaMarcaCres(int categoria, string marca)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.IdCategoria == categoria && a.IdEquipamentoNavigation.Marca == marca)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderBy(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }
        public async Task<List<Classificado>> FiltroCategoriaMarcaDecres(int categoria, string marca)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.IdCategoria == categoria && a.IdEquipamentoNavigation.Marca == marca)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderByDescending(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroCategoriaCres(int categoria)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.IdCategoria == categoria)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderBy(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroCategoriaDecres(int categoria)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.IdCategoria == categoria)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderByDescending(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroMarcaCres(string marca)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.Marca == marca)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderBy(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroMarcaDecres(string marca)
        {
            List<Classificado> listaClassificados = await context.Classificado.Where(a => a.IdEquipamentoNavigation.Marca == marca)
                                                                              .Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderByDescending(d => d.Preco)
                                                                              .ToListAsync();

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroCres()
        {
            List<Classificado> listaClassificados = await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderBy(d => d.Preco)
                                                                              .ToListAsync();                                                                                                                                              

            return listaClassificados;
        }

        public async Task<List<Classificado>> FiltroDecres()
        {
            List<Classificado> listaClassificados = await context.Classificado.Include(b => b.IdEquipamentoNavigation)
                                                                              .Include(c => c.IdImagemClassificadoNavigation)
                                                                              .Include(E => E.Interesse)
                                                                              .OrderByDescending(d => d.Preco)
                                                                              .ToListAsync(); 

            return listaClassificados;
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