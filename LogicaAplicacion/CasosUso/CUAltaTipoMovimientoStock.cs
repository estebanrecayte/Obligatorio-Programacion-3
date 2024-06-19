using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaTipoMovimientoStock : ICUAlta<TipoMovimientoStockDTO>
    {
        public IRepositorioTipoMovimientoStock Repo { get; set; }

        public CUAltaTipoMovimientoStock(IRepositorioTipoMovimientoStock repo)
        {
            Repo = repo;
        }
        public void Alta(TipoMovimientoStockDTO obj)
        {
            TipoMovimientoStock tipoMovimientoStock = MapperTipoMovimientoStock.ToTipoMovimientoStock(obj);
            if (tipoMovimientoStock.Nombre == obj.Nombre)
            {
                throw new ExcepcionPropiaException("Ese tipo de movimiento ya esta creado!");
            }
            if (tipoMovimientoStock.Id == obj.Id)
            {
                throw new ExcepcionPropiaException("El id se genera automaticamente. PD: este Id aparte ya esta en uso >) ");
            }
            Repo.Add(tipoMovimientoStock);
        }
    }
}
