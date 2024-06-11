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
    public class CUListadoTipoMovimientoStock : ICUListado<TipoMovimientoStockDTO>
    {
        public IRepositorioTipoMovimientoStock Repo { get; set; }
        public CUListadoTipoMovimientoStock(IRepositorioTipoMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<TipoMovimientoStockDTO> ObtenerListado()
        {
            List<TipoMovimientoStockDTO> dtos = new List<TipoMovimientoStockDTO>();
            List<TipoMovimientoStock> tipos = Repo.FindAll();
            if (tipos.Count > 0)
            {
                dtos = MapperTipoMovimientoStock.ToListDto(tipos);
            }
            return dtos;
        }
    }
}
