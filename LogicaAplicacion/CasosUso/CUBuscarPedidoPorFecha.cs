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
    public class CUBuscarPedidoPorFecha:ICUBuscarPedidoPorFecha
    {
        public IRepositorioPedido Repo { get; set; }
        public CUBuscarPedidoPorFecha(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public List<Pedido> FindByFechaEmision(DateTime fechaEmision)
        {
            return Repo.FindByFechaEmision(fechaEmision);
        }
    }
}
