using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Articulos")]
    public class Articulo:IValidable
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Articulo() { }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("El nombre del artículo no puede estar vacío.");
            }

            if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 5)
            {
                throw new DatosInvalidosException("La descripción del artículo debe tener al menos 5 caracteres.");
            }

            if (Codigo <= 0)
            {
                throw new DatosInvalidosException("El código del artículo debe ser un número positivo.");
            }

            int contadorDigitos = 0;
            long codigoTemp = Codigo;

            while (codigoTemp != 0)
            {
                contadorDigitos++;
                codigoTemp /= 10;
            }

            if (contadorDigitos != 13)
            {
                throw new DatosInvalidosException("El código del artículo debe tener 13 dígitos.");
            }

            if (Precio <= 0)
            {
                throw new DatosInvalidosException("El precio del artículo debe ser mayor que cero.");
            }

            if (Stock < 0)
            {
                throw new DatosInvalidosException("El stock del artículo no puede ser negativo.");
            }
        }
    }
}
