using LogicaNegocio.ExcepcionPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class DireccionCliente
    {
        public string Calle { get; }
        public string Numero { get; }
        public string Ciudad { get; }

        public DireccionCliente(string calle, string numero, string ciudad)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
        }

        private DireccionCliente()
        {
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle) || string.IsNullOrEmpty(Numero) || string.IsNullOrEmpty(Ciudad))
            {
                throw new DatosInvalidosException("La calle, número y ciudad son obligatorios.");
            }
        }

    }
}