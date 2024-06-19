using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimientoStock
    {
        void Add(MovimientoStock obj);
        List<MovimientoStock> FindAll();
        MovimientoStock FindById(int id);
        public List<MovimientoStock> MovimientosAMostrarPorPagina(int pagina);
        public int CantidadTotalMovimientoStock();
        public List<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId, int pagina);

        public int ObtenerCantidadTotalMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId);


        public List<Articulo> ObtenerArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin, int pagina);

        public int CantidadTotalArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin);

        public List<ResumenMovimientoStock> ObtenerResumenMovimientos();
    }
}
