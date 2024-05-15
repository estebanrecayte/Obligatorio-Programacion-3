using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerListadoAnulados : ICUObtenerListadoAnulados
    {
        public IRepositorioPedido Repo { get; set; }
        public CUObtenerListadoAnulados(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public List<Pedido> PedidosAnulados()
        {
            return Repo.PedidosAnulados();
        }
    }
}
