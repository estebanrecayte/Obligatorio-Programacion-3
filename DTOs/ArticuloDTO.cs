﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ArticuloDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
