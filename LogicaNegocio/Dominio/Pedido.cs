using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public static int UltId { get; set; } = 0;
        public DateTime Fecha { get; set; }
        public Cliente cliente { get; set; }
        public List<Linea> Lineas { get; set; } = new List<Linea>();
        public double Recargo { get; set; }

        public Pedido()
        {

            UltId++;
            Id = UltId;

        }
    }
}
