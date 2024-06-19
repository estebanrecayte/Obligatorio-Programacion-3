using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ResumenMovimientoStockDTO
    {
        public int Año { get; set; }
        public List<DetalleMovimientoDTO> DetallesPorTipo { get; set; }
        public int TotalAño { get; set; }
    }
}
