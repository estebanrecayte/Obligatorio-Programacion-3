
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioMovimientoStockEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(MovimientoStock obj)
        {
            if (!obj.TipoMovimientoStock.ModificaStock)
            {
                throw new ExcepcionPropiaException("El tipo de movimiento no modifica el stock y no puede ser registrado como movimiento de stock.");
            }

            Contexto.Entry(obj.Usuario).State = EntityState.Unchanged;
            Contexto.Entry(obj.TipoMovimientoStock).State = EntityState.Unchanged;
            Contexto.Entry(obj.Articulo).State = EntityState.Unchanged;

            Contexto.MovimientosDeStock.Add(obj);
            Contexto.SaveChanges();
        }

        public List<MovimientoStock> FindAll()
        {
            return Contexto.MovimientosDeStock
                .Include(movimiento => movimiento.Articulo)
                .Include(movimiento => movimiento.TipoMovimientoStock)
                .Include(movimiento => movimiento.Usuario)
                .ToList();
        }

        public MovimientoStock FindById(int id)
        {
            return Contexto.MovimientosDeStock.Find(id);
        }

        
        public List<MovimientoStock> MovimientosAMostrarPorPagina(int pagina)
        {
            return Contexto.MovimientosDeStock
                .Include(movimiento => movimiento.Articulo)
                .Include(movimiento => movimiento.TipoMovimientoStock)
                .Include(movimiento => movimiento.Usuario)
                .Skip((pagina - 1) * Parametro.Paginado)
                .Take(Parametro.Paginado)
                .ToList();
        }

        public int CantidadTotalMovimientoStock()
        {
            return Contexto.MovimientosDeStock.Count();
        }

        public List<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId, int pagina)
        {
            var movimientos = Contexto.MovimientosDeStock
                                        .Include(movimiento => movimiento.Articulo)
                                        .Include(movimiento => movimiento.TipoMovimientoStock)
                                        .Include(movimiento => movimiento.Usuario)
                                        .Where(m => m.Articulo.Codigo == articuloId && m.TipoMovimientoStock.Id == tipoMovimientoId)
                                        .OrderByDescending(m => m.FechaHora)
                                        .ThenBy(m => m.Cantidad)
                                        .Skip((pagina - 1) * Parametro.Paginado)
                                        .Take(Parametro.Paginado)
                                        .ToList();
            return movimientos;
        }

        public int ObtenerCantidadTotalMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId)
        {
            return Contexto.MovimientosDeStock
                           .Count(m => m.Articulo.Codigo == articuloId && m.TipoMovimientoStock.Id == tipoMovimientoId);
        }

        public List<Articulo> ObtenerArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin, int pagina)
        {
            var articulos = Contexto.MovimientosDeStock
                                        .Include(movimiento => movimiento.Articulo)
                                        .Include(movimiento => movimiento.TipoMovimientoStock)
                                        .Include(movimiento => movimiento.Usuario)
                                        .Where(movimiento => movimiento.FechaHora >= fechaInicio && movimiento.FechaHora <= fechaFin)
                                        .Select(movimiento => movimiento.Articulo)
                                        .Distinct()
                                        .Skip((pagina - 1) * Parametro.Paginado)
                                        .Take(Parametro.Paginado)
                                        .ToList();

            return articulos;
        }

        public int CantidadTotalArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var cantidadArticulos = Contexto.MovimientosDeStock
                                            .Where(movimiento => movimiento.FechaHora >= fechaInicio && movimiento.FechaHora <= fechaFin)
                                            .Select(movimiento => movimiento.ArticuloId)
                                            .Distinct()
                                            .Count();

            return cantidadArticulos;
        }

        public List<ResumenMovimientoStock> ObtenerResumenMovimientos()
        {
            var resumenAgrupadoPorAño = Contexto.MovimientosDeStock
                .GroupBy(m => new { Año = m.FechaHora.Year, Tipo = m.TipoMovimientoStock.Nombre }) // agrupar movimientos por el anio y el nombre del tipo de movimiento
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Tipo = g.Key.Tipo,
                    Cantidad = g.Sum(m => m.Cantidad)
                }) // seleccionar los datos necesarios
                .GroupBy(r => r.Año) // agrupacion secundaria por anio
                .Select(g => new ResumenMovimientoStock
                {
                    Año = g.Key, // anio como key
                    DetallesPorTipo = g.Select(x => new DetalleMovimiento
                    {
                        Tipo = x.Tipo,
                        Cantidad = x.Cantidad
                    }).ToList(),// generar una lista con cada tipo de movimiento dentro del grpo y su cantidad respectiva
                    TotalAño = g.Sum(x => x.Cantidad)
                })
                .ToList();

            return resumenAgrupadoPorAño;
        }
    }
}
