﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Express : Pedido
    {
        public static int PlazoEnDiasEntrega { get; set; }
    }
}
