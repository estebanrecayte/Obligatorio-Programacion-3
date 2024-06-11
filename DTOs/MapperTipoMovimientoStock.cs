using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperTipoMovimientoStock
    {
        public static TipoMovimientoStock ToTipoMovimientoStock(TipoMovimientoStockDTO dto)
        {
            TipoMovimientoStock tipoMovimientoStock = new TipoMovimientoStock
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                ModificaStock = dto.ModificaStock
            };

            return tipoMovimientoStock;
        }
        public static TipoMovimientoStockDTO ToTipoMovimientoStockDTO(TipoMovimientoStock tipoMovimientoStock)
        {
            TipoMovimientoStockDTO dto = new TipoMovimientoStockDTO
            {
                Id = tipoMovimientoStock.Id,
                Nombre = tipoMovimientoStock.Nombre,
                ModificaStock = tipoMovimientoStock.ModificaStock
            };

            return dto;
        }

        public static List<TipoMovimientoStockDTO> ToListDto(List<TipoMovimientoStock> tiposMovimientoStock)
        {
            return tiposMovimientoStock.Select(tipo => new TipoMovimientoStockDTO()
            {
                Id = tipo.Id,
                Nombre = tipo.Nombre,
                ModificaStock = tipo.ModificaStock
            })
            .ToList();
        }

    }
}
