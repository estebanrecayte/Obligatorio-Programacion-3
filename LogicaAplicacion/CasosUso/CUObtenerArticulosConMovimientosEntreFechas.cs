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
    public class CUObtenerArticulosConMovimientosEntreFechas : ICUObtenerArticulosConMovimientosEntreFechas
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUObtenerArticulosConMovimientosEntreFechas(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<ArticuloDTO> ObtenerArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin, int pagina)
        {
            var aux = Repo.ObtenerArticulosConMovimientosEntreFechas(fechaInicio, fechaFin, pagina);
            return MapperArticulo.ToListDto(aux);
        }

        public int CantidadTotalArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return Repo.CantidadTotalArticulosConMovimientosEntreFechas(fechaInicio,fechaFin);
        }
    }
}
