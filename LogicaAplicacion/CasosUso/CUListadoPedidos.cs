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
    public class CUListadoPedidos : ICUListado<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }
        public CUListadoPedidos(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public List<Pedido> ObtenerListado()
        {
            return Repo.FindAll();
        }

        public Pedido BuscarPorId(int id)
        {
            return Repo.FindById(id);
        }
    }
}
