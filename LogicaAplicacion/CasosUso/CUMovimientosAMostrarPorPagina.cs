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
    public class CUMovimientosAMostrarPorPagina : ICUMovimientosAMostrarPorPagina
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUMovimientosAMostrarPorPagina(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<MovimientoStockDTOSimple> MovimientosAMostrarPorPagina(int pagina)
        {
            List<MovimientoStock> movimientosAMostrar = Repo.MovimientosAMostrarPorPagina(pagina);
            return MapperMovimientoStock.ToListDtoSimple(movimientosAMostrar);
        }
    }
}
