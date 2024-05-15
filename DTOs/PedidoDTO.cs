using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PedidoDTO
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaEntregaPrometida { get; set; }
        public int IdCliente { get; set; }
        public long CodigoProducto { get; set; }
        public int CantidadProducto { get; set; }
        public string TipoPedido { get; set; }
        public bool Estado { get; set; }
    }
}
