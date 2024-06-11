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
    public class CUModificarTipoMovimientoStock : ICUModificar<TipoMovimientoStockDTO>
    {
        public IRepositorioTipoMovimientoStock Repo { get; set; }

        public CUModificarTipoMovimientoStock(IRepositorioTipoMovimientoStock repo)
        {
            Repo = repo;
        }

        public void Modificar(TipoMovimientoStockDTO obj)
        {
            TipoMovimientoStock tipo = MapperTipoMovimientoStock.ToTipoMovimientoStock(obj);
            Repo.Update(tipo);
        }
    }
}
