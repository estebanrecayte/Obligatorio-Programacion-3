using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class MovimientoStock:IValidable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [ForeignKey("Articulo")]
        public long ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        [ForeignKey("TipoMovimientoStock")]
        public int TipoMovimientoStockId { get; set; }
        public TipoMovimientoStock TipoMovimientoStock { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public void EsValido()
        {
            if (Cantidad <= 0)
            {
                throw new DatosInvalidosException("La cantidad del movimiento debe ser mayor que cero.");
            }

            if (Articulo == null)
            {
                throw new DatosInvalidosException("El movimiento debe estar asociado a un artículo.");
            }

            if (TipoMovimientoStock == null)
            {
                throw new DatosInvalidosException("El movimiento debe tener un tipo de movimiento asociado.");
            }

            if (Usuario == null)
            {
                throw new DatosInvalidosException("El movimiento debe estar registrado por un usuario.");
            }
        }
    }
}

