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
    public class CUListadoUsuario : ICUListado<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public List<Usuario> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
