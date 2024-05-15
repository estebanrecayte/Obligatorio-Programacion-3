using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public abstract class Pedido : IValidable
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public List<Linea> Lineas { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntregaPrometida { get; set; }

        public bool Estado { get; set; }

        public double Precio { get; set; }


        
        
        public double CalcularTotalPedido()
        {

            double total = 0;

            foreach (var linea in Lineas)
            {
                total += linea.PrecioUnitario * linea.Cantidad;
            }

            double montoIVA = total * Parametro.TasaIVA;

            total += montoIVA;

            return total;
        }


        public abstract double CalcularTotalConRecargo();

        public void EsValido()
        {
            
            if (Cliente == null)
            {
                throw new DatosInvalidosException("El cliente asociado al pedido no existe.");
            }

            if (Lineas == null || Lineas.Count == 0)
            {
                throw new DatosInvalidosException("El pedido debe contener al menos un artículo.");
            }

            if (Estado && FechaEntregaPrometida <= DateTime.Today)
            {
                throw new DatosInvalidosException("La fecha de entrega prometida debe ser igual o posterior a la fecha actual.");
            }


        }
    }
}

