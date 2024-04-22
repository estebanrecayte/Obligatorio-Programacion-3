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
    public class CUBajaCliente : ICUBaja<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBajaCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
