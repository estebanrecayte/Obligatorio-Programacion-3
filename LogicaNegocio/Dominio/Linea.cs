using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Linea
    {
        public Articulo articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public Linea() { }
    }
}
