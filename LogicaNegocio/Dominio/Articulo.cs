using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Articulos")]
    public class Articulo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Articulo() { }
    }
}
