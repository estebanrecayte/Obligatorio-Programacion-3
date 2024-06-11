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
    public class CUBajaTipoMovimientoStock : ICUBaja<TipoMovimientoStockDTO>
    {
        public IRepositorioTipoMovimientoStock Repo { get; set; }

        public CUBajaTipoMovimientoStock(IRepositorioTipoMovimientoStock repo)
        {
            Repo = repo;
        }

        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
