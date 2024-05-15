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
    public class CUBuscarClientePorId : ICUBuscarPorId<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientePorId(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public Cliente Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
