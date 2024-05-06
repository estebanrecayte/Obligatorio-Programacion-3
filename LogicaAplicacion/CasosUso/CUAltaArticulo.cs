using DTOs;
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
    public class CUAltaArticulo : ICUAlta<ArticuloDTO>
    {
        public IRepositorioArticulo Repo {  get; set; }

        public CUAltaArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }
            
        public void Alta(ArticuloDTO obj)
        {
            Articulo nuevo = MapperArticulo.ToArticulo(obj);
            Repo.Add(nuevo);
        }
    }
}
