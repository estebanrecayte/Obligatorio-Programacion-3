using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerMovimientosPorArticuloYTipo : ICUObtenerMovimientosPorArticuloYTipo
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUObtenerMovimientosPorArticuloYTipo(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<MovimientoStockDTOSimple> ObtenerMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId, int pagina)
        {
            List<MovimientoStock> movimientosAMostrar = Repo.ObtenerMovimientosPorArticuloYTipo(articuloId, tipoMovimientoId, pagina);
            return MapperMovimientoStock.ToListDtoSimple(movimientosAMostrar);
        }

        public int ObtenerCantidadTotalMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId)
        {
            return Repo.ObtenerCantidadTotalMovimientosPorArticuloYTipo(articuloId, tipoMovimientoId);
        }
    }
}
