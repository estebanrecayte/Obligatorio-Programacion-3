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
    public class CUModificarMovimientoStock : ICUModificar<MovimientoStockDTO>
    {
        public IRepositorioMovimientoStock Repo {  get; set; }

        public CUModificarMovimientoStock(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public void Modificar(MovimientoStockDTO obj)
        {
            MovimientoStock movimiento = MapperMovimientoStock.ToMovimientoStock(obj);
            Repo.Update(movimiento);
        }
    }
}
