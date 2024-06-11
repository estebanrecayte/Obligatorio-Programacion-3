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
    public class CUAltaMovimientoStock : ICUAlta<MovimientoStockDTO>
    {
        public IRepositorioMovimientoStock RepoMovimientoStock { get; set; }
        public IRepositorioArticulo RepoArticulo { get; set; }
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioTipoMovimientoStock RepoTipoMovimientoStock { get; set; }

        public CUAltaMovimientoStock(IRepositorioMovimientoStock repoMovimientoStock, IRepositorioArticulo repoArticulo, IRepositorioUsuario repoUsuario, IRepositorioTipoMovimientoStock repoTipoMovimientoStock)
        {
            RepoMovimientoStock = repoMovimientoStock;
            RepoArticulo = repoArticulo;
            RepoUsuario = repoUsuario;
            RepoTipoMovimientoStock = repoTipoMovimientoStock;
        }

        public void Alta(MovimientoStockDTO movimientoStockDTO)
        {
            Articulo articulo = RepoArticulo.GetByCodigo(movimientoStockDTO.ArticuloId);
            Usuario usuario = RepoUsuario.FindById(movimientoStockDTO.UsuarioId);
            TipoMovimientoStock tipoMovimientoStock = RepoTipoMovimientoStock.FindById(movimientoStockDTO.TipoMovimientoStockId);

            if (articulo == null)
            {
                throw new ExcepcionPropiaException("El artículo asociado al movimiento de stock no existe.");
            }

            if (usuario == null)
            {
                throw new ExcepcionPropiaException("El usuario asociado al movimiento de stock no existe.");
            }

            if (tipoMovimientoStock == null)
            {
                throw new ExcepcionPropiaException("El tipo de movimiento de stock asociado al movimiento de stock no existe.");
            }

            MovimientoStock movimientoStock = MapperMovimientoStock.ToMovimientoStock(movimientoStockDTO);

            movimientoStock.Articulo = articulo;
            movimientoStock.Usuario = usuario;
            movimientoStock.TipoMovimientoStock = tipoMovimientoStock;

            RepoMovimientoStock.Add(movimientoStock);
        }
    }
}
