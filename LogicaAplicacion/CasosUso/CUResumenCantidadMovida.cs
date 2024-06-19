using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUResumenCantidadMovida : ICUResumenCantidadMovida
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUResumenCantidadMovida(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }
        public List<ResumenMovimientoStockDTO> ObtenerResumen()
        {
            var aux = Repo.ObtenerResumenMovimientos();
            return MovimientoStockMapper.MapToDTO(aux).ToList();
        }
    }
}
