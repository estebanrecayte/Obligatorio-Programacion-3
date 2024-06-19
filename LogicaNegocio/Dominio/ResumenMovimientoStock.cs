using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class ResumenMovimientoStock
    {
        public int Año { get; set; }
        public List<DetalleMovimiento> DetallesPorTipo { get; set; }
        public int TotalAño { get; set; }
    }
}
