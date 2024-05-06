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
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public DateTime FechaEntregaPrometida { get; set; }

        public long CodigoProducto { get; set; }
        public string TipoPedido { get; set; }
    }
}
