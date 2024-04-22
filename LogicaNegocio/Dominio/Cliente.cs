using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Clientes")]
    public class Cliente:IValidable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long Rut { get; set; }
        public string RazonSocial { get; set; }
        public DireccionCliente Direccion { get; set; }
        public int DistanciaKm { get; set; }

        public Cliente()
        {
            
        }

        public void EsValido()
        {
            if (!EsRutValido(Rut))
            {
                throw new DatosInvalidosException("El RUT debe ser un número de 12 digitos");
            }
        }

        private bool EsRutValido(long rut)
        {
            int count = 0;
            while (rut != 0)
            {
                count++;
                rut /= 10;
            }
            return count == 12;
        }


    }
}
