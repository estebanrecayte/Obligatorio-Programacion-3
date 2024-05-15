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
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El codigo del artículo debe tener 13 digitos")]
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Articulo() { }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("No puede estar vacio el nombre del articulo");
            }

            if (Nombre.Length < 10 || Nombre.Length > 200)
            {
                throw new DatosInvalidosException("El nombre del articulo debe tener entre 10 y 200 caracteres");
            }

            if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 5)
            {
                throw new DatosInvalidosException("La descripcion del articulo no puede estar vacia debe tener al menos 5 caracteres");
            }

            if (Codigo <= 0)
            {
                throw new DatosInvalidosException("El codigo no puede ser negativo");
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
                throw new DatosInvalidosException("El codigo del artículo debe tener 13 digitos");
            }

            if (Precio <= 0)
            {
                throw new DatosInvalidosException("El precio del artículo debe ser mayor que cero");
            }

            if (Stock <= 0)
            {
                throw new DatosInvalidosException("El stock del artículo no puede ser negativo");
            }
        }
    }
}
