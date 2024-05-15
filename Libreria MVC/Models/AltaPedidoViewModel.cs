using DTOs;
using LogicaNegocio.Dominio;

namespace Libreria_MVC.Models
{
    public class AltaPedidoViewModel
    {
        public DateTime FechaEntregaPrometida { get; set; }
        public int IdClienteSeleccionado { get; set; }
        public List<Cliente>? Clientes { get; set; }
        public long CodigoArticuloSeleccionado { get; set; }
        public List<Articulo>? Articulos { get; set; }
        public int CantidadSeleccionada { get; set; }
        public string TipoPedido { get; set; }

    }
}
