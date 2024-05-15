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
    public class CUBuscarArticuloPorCodigo : ICUBuscarArticuloPorCodigo
    {
        public IRepositorioArticulo Repo {  get; set; }
        public CUBuscarArticuloPorCodigo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public Articulo BuscarArticuloPorCodigo(long codigo)
        {
            return Repo.GetByCodigo(codigo);
        }
    }
}
