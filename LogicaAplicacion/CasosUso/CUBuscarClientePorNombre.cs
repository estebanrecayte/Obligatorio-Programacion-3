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
    public class CUBuscarClientePorNombre : ICUBuscarClientePorNombre
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientePorNombre(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public Cliente BuscarPorNombre(string nombre)
        {
            return Repo.BuscarClientePorNombre(nombre);
        }
    }
}
