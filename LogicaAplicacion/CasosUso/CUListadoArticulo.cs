using DTOs;
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
    public class CUListadoArticulo : ICUListado<ArticuloDTO>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUListadoArticulo (IRepositorioArticulo repo)
        {
            Repo = repo;
        }
        public List<ArticuloDTO> ObtenerListado()
        {
            List<ArticuloDTO> dtos = new List<ArticuloDTO>();
            List<Articulo> articulos = Repo.FindAll();
            if (articulos.Count > 0)
            {
                dtos = MapperArticulo.ToListDto(articulos);
            }
            return dtos;
        }

        
    }
}
