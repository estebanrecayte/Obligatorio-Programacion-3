using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Comun : Pedido
    {
        public override double CalcularTotalConRecargo()
        {
            double recargo = 0;

            int distanciaEntregaKm = cliente.DistanciaKm;

            if (distanciaEntregaKm > 100)
            {
                recargo = CalcularTotalPedido() * 0.05; // 5% del total del pedido
            }

            double totalPedidoConRecargo = CalcularTotalPedido() + recargo;

            return totalPedidoConRecargo;
        }
    }


}
