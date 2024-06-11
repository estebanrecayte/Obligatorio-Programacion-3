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
    public class CUBuscarMovimientoStockPorId : ICUBuscarPorId<MovimientoStockDTO>
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUBuscarMovimientoStockPorId(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public MovimientoStockDTO Buscar(int id)
        {
            MovimientoStockDTO movimiento = null;
            MovimientoStock buscado = Repo.FindById(id);
            if (buscado != null)
            {
                movimiento = MapperMovimientoStock.ToMovimientoStockDTO(buscado);
            }
            return movimiento;
        }
    }
}
