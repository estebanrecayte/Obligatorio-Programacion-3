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
    public class CUBuscarPedidoPorId : ICUBuscarPorId<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUBuscarPedidoPorId(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public Pedido Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
