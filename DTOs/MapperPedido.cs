using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperPedido
    {
        public static Comun ToPedidoComun(PedidoDTO dto)
        {
            Comun pComun = new Comun
            {
                Fecha = dto.Fecha,
                FechaEntregaPrometida = dto.FechaEntregaPrometida,
                Estado = dto.Estado,
            };

            return pComun;
        }

        public static Express ToPedidoExpress(PedidoDTO dto)
        {
            Express pExpress = new Express
            {
                Fecha = dto.Fecha,
                FechaEntregaPrometida = dto.FechaEntregaPrometida, 
                Estado = dto.Estado,
            };

            return pExpress;
        }

        
    }
}
