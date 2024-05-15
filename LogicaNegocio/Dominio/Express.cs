using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Express : Pedido
    {
        

        public override double CalcularTotalConRecargo()
        {
            
            double recargo = 0;

            if (EsEntregaMismoDia())
            {
                recargo = CalcularTotalPedido() * Parametro.RecargoEntregaMismoDia;
            }
            else if (EsEntregaDentroPlazo())
            {
                recargo = CalcularTotalPedido() * Parametro.RecargoExpressPorDefecto;
            }

            double totalPedidoConRecargo = CalcularTotalPedido() + recargo;

            return totalPedidoConRecargo;
        }

        private bool EsEntregaMismoDia()
        {
            DateTime fechaActual = DateTime.Today;
            return FechaEntregaPrometida.Date == fechaActual;
        }

        private bool EsEntregaDentroPlazo()
        {
            DateTime fechaActual = DateTime.Today;

            TimeSpan diferencia = FechaEntregaPrometida.Date - fechaActual;

            return diferencia.Days <= Parametro.PlazoMaximoEntrega;
        }
    }
}
