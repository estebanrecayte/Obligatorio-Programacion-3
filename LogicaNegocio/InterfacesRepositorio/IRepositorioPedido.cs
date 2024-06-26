﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        double ObtenerImporteTotalPedido(int id);

        List<Pedido> FindByFechaEmision(DateTime fechaEmision);

        List<Pedido> PedidosAnulados();
    }
}
