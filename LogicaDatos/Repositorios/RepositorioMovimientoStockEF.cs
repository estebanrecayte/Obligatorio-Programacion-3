using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioMovimientoStockEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(MovimientoStock obj)
        {
            Contexto.Entry(obj.Usuario).State = EntityState.Unchanged;
            Contexto.Entry(obj.TipoMovimientoStock).State = EntityState.Unchanged;
            Contexto.Entry(obj.Articulo).State = EntityState.Unchanged;

            Contexto.MovimientosDeStock.Add(obj);
            Contexto.SaveChanges();
        }

        public List<MovimientoStock> FindAll()
        {
            return Contexto.MovimientosDeStock.ToList();
        }

        public MovimientoStock FindById(int id)
        {
            return Contexto.MovimientosDeStock.Find(id);
        }

        public void Remove(int id)
        {
            var movimiento = Contexto.MovimientosDeStock.Find(id);
            if (movimiento != null)
            {
                Contexto.MovimientosDeStock.Remove(movimiento);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionPropiaException("No se encontró el movimiento de stock.");
            }
        }

            public void Update(MovimientoStock obj)
        {
            var movimiento = Contexto.MovimientosDeStock.Find(obj.Id);
            if (movimiento != null)
            {
                movimiento.FechaHora = obj.FechaHora;
                movimiento.ArticuloId = obj.ArticuloId;
                movimiento.TipoMovimientoStockId = obj.TipoMovimientoStockId;
                movimiento.UsuarioId = obj.UsuarioId;
                movimiento.Cantidad = obj.Cantidad;
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionPropiaException("No se encontró el movimiento de stock.");
            }
        }
    }
}
