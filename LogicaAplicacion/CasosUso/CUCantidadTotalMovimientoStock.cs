using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUCantidadTotalMovimientoStock : ICUCantidadTotalMovimientoStock
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUCantidadTotalMovimientoStock(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public int CantidadTotalDeMovimientos()
        {
            return Repo.CantidadTotalMovimientoStock();
        }
    }
}
