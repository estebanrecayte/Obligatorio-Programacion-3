using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public static class Parametro
    {
        public static double RecargoExpressPorDefecto { get; set; } = 0.10;
        public static double RecargoEntregaMismoDia { get; set; } = 0.15; 
        public static double RecargoComunPorDefecto { get; set; } = 0.05; 
        public static int DistanciaLimiteComun { get; set; } = 100; 
        public static double TasaIVA { get; set; } = 0.22;
        public static int PlazoMaximoEntrega { get; set; } = 5;
        public static int CantidadMaximaMovimiento { get; set; } = 20;

        public static int Paginado { get; set; } = 2;
    }
}
