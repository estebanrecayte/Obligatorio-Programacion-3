using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionPropias
{
    public class ExcepcionPropiaException : Exception
    {
        public ExcepcionPropiaException() { }

        public ExcepcionPropiaException(string mensaje) : base(mensaje)
        {
        }

        public ExcepcionPropiaException(string mensaje, Exception interna) : base(mensaje, interna)
        {
        }
    }
}
