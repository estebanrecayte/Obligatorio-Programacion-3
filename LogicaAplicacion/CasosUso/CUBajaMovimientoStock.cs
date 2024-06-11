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
    public class CUBajaMovimientoStock : ICUBaja<MovimientoStockDTO>
    {
        public IRepositorioMovimientoStock Repo { get; set; }

        public CUBajaMovimientoStock(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
