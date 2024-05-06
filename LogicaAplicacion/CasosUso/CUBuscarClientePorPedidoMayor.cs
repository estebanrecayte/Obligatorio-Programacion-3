using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarClientePorPedidoMayor : ICUBuscarClientePorPedidoMayor
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientePorPedidoMayor(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public List<Cliente> BuscarClientePorPedidoMayorA(double precio)
        {
            return Repo.ClientesConPedidosMayoresA(precio);
        }
    }
}
