using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerImporteTotalPedido:ICUObtenerImporteTotalPedido
    {
        public IRepositorioPedido Repo { get; set; }
        public CUObtenerImporteTotalPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public double ObtenerImporteTotalPedido(int id)
        {
            return Repo.ObtenerImporteTotalPedido(id);
        }
    }
}
