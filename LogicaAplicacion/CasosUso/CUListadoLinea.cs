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
    public class CUListadoLinea : ICUListado<Linea>
    {
        public IRepositorioLinea Repo { get; set; }
        public CUListadoLinea(IRepositorioLinea repo)
        {
            Repo = repo;
        }

        public List<Linea> ObtenerListado()
        {
            return Repo.FindAll();
        }

        
    }
}
