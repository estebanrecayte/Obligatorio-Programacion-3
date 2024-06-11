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
    public class CUBuscarTipoMovimientoStockPorId:ICUBuscarPorId<TipoMovimientoStockDTO>
    {
        public IRepositorioTipoMovimientoStock Repo { get; set; }
        public CUBuscarTipoMovimientoStockPorId(IRepositorioTipoMovimientoStock repo)
        {
            Repo = repo;
        }
        public TipoMovimientoStockDTO Buscar(int id)
        {
            TipoMovimientoStockDTO tipo = null;
            TipoMovimientoStock buscado = Repo.FindById(id);
            if (buscado != null)
            {
                tipo = MapperTipoMovimientoStock.ToTipoMovimientoStockDTO(buscado);
            }
            return tipo;
        }
    }
}
