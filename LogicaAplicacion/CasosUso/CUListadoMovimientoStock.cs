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
    public class CUListadoMovimientoStock : ICUListado<MovimientoStockDTO>
    {
        public IRepositorioMovimientoStock Repo { get; set; }

        public CUListadoMovimientoStock(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<MovimientoStockDTO> ObtenerListado()
        {
            List<MovimientoStockDTO> dtos = new List<MovimientoStockDTO>();
            List<MovimientoStock> movimientos = Repo.FindAll();
            if (movimientos.Count > 0)
            {
                dtos = MapperMovimientoStock.ToListDto(movimientos);
            }
            return dtos;
        }
    }
}
