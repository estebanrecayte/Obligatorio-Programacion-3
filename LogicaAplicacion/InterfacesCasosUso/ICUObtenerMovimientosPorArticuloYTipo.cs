﻿using DTOs;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface ICUObtenerMovimientosPorArticuloYTipo
    {
        public List<MovimientoStockDTOSimple> ObtenerMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId, int pagina);

        public int ObtenerCantidadTotalMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId);
    }
}
