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
    public class CUListadoCliente:ICUListado<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUListadoCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public List<Cliente> ObtenerListado()
        {
            return Repo.FindAll();
        }

        
    }
}
