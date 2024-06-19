using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface ICUObtenerArticulosConMovimientosEntreFechas
    {
        public List<ArticuloDTO> ObtenerArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin, int pagina);

        public int CantidadTotalArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}
