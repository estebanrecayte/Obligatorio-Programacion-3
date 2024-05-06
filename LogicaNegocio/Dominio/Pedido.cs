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
    public abstract class Pedido:IValidable
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaEntregaPrometida { get; set; }

        public static double tasaIVA = 22;

        public double CalcularTotalPedido()
        {
            
            double total = 0;

            foreach (var linea in Lineas)
            {
                total += linea.PrecioUnitario * linea.Cantidad;
            }

            double montoIVA = total * (tasaIVA / 100);

            total += montoIVA;

            return total;
        }


        public abstract double CalcularTotalConRecargo();

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
