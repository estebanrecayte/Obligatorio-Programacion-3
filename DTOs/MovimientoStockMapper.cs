using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public static class MovimientoStockMapper
    {
        public static ResumenMovimientoStockDTO MapToDTO(ResumenMovimientoStock resumen)
        {
            return new ResumenMovimientoStockDTO
            {
                Año = resumen.Año,
                DetallesPorTipo = resumen.DetallesPorTipo.Select(d => new DetalleMovimientoDTO
                {
                    Tipo = d.Tipo,
                    Cantidad = d.Cantidad
                }).ToList(),
                TotalAño = resumen.TotalAño
            };
        }

        public static IEnumerable<ResumenMovimientoStockDTO> MapToDTO(IEnumerable<ResumenMovimientoStock> resumenes)
        {
            return resumenes.Select(r => MapToDTO(r)).ToList();
        }
    }
}
