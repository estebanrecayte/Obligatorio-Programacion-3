using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovimientoStockDTOSimple
    {
        public DateTime FechaHora { get; set; }
        public string Articulo { get; set; }
        public string Usuario { get; set; }
        public string TipoMovimientoStock { get; set; }
        public int Cantidad { get; set; }
    }
}
