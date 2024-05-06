using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Linea:IValidable
    {
        public int PedidoId { get; set; }
        public long ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public Pedido Pedido { get; set; }
        public Linea() { }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
