using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovimientoStockDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public long ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoMovimientoStockId { get; set; }
        public int Cantidad { get; set; }
    }
}
