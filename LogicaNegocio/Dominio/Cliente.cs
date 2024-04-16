using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Clientes")]
    public class Cliente:IValidable
    {
        public int Id { get; set; }
        public static int UltId { get; set; } = 0;
        public long Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int DistanciaKm { get; set; }

        public Cliente(long rut, string razonSocial, string direccion, int distanciaKm)
        {
            UltId++;
            Id = UltId;
            Rut = rut;
            RazonSocial = razonSocial;
            Direccion = direccion;
            DistanciaKm = distanciaKm;

        }

        public void EsValido()
        {
            if (!EsRutValido(Rut))
            {
                throw  new Exception("El RUT debe ser un número de 12 digitos");
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
