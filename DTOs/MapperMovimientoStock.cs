using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperMovimientoStock
    {
        public static MovimientoStock ToMovimientoStock(MovimientoStockDTO dto)
        {
            MovimientoStock movimientoStock = new MovimientoStock
            {
                Id = dto.Id,
                FechaHora = dto.FechaHora,
                ArticuloId = dto.ArticuloId,
                UsuarioId = dto.UsuarioId,
                TipoMovimientoStockId = dto.TipoMovimientoStockId,
                Cantidad = dto.Cantidad
            };

            return movimientoStock;
        }

        public static MovimientoStockDTO ToMovimientoStockDTO(MovimientoStock movimientoStock)
        {
            MovimientoStockDTO dto = new MovimientoStockDTO
            {
                Id = movimientoStock.Id,
                FechaHora = movimientoStock.FechaHora,
                ArticuloId = movimientoStock.ArticuloId,
                UsuarioId = movimientoStock.UsuarioId,
                TipoMovimientoStockId = movimientoStock.TipoMovimientoStockId,
                Cantidad = movimientoStock.Cantidad
            };

            return dto;
        }

        public static List<MovimientoStockDTO> ToListDto(List<MovimientoStock> movimientos)
        {
            return movimientos.Select(movimiento => new MovimientoStockDTO()
            {
                Id = movimiento.Id,
                FechaHora = movimiento.FechaHora,
                ArticuloId = movimiento.ArticuloId,
                UsuarioId = movimiento.UsuarioId,
                TipoMovimientoStockId = movimiento.TipoMovimientoStockId,
                Cantidad = movimiento.Cantidad
            })
            .ToList();
        }
    }
}
