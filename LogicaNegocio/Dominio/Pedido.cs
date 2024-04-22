using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pedido:IValidable
    {
        public int Id { get; set; }
        public static int UltId { get; set; } = 0;
        public DateTime Fecha { get; set; }
        public Cliente cliente { get; set; }
        public List<Linea> Lineas { get; set; } = new List<Linea>();
        public DateTime FechaEntregaPrometida { get; set; }

        public static double tasaIVA = 22;
        

        public Pedido()
        {
            Id=UltId++;
        }

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


        public virtual double CalcularTotalConRecargo() { return 0; }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
