﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioCliente:IRepositorio<Cliente>
    {
        List<Cliente> BuscarClientePorNombre(string nombre);

        List<Cliente> ClientesConPedidosMayoresA(double precio);
    }
}
