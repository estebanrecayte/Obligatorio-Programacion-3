using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedidoEF(LibreriaContext ctx)
        {
            Contexto = ctx;

        }

        public void Add(Pedido obj)
        {
            obj.EsValido();
            Contexto.Pedidos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Remove(int id)
        {
            Pedido aBorrar = FindById(id);
            if (aBorrar != null)
            {
                Contexto.Pedidos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new Exception("No existe el pedido a borrar");
            }
        }

        public void Update(Pedido obj)
        {
            obj.EsValido();
            Contexto.Pedidos.Update(obj);
            Contexto.SaveChanges();
        }

        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos
                .Include(p => p.Cliente)   // Incluir el cliente asociado a cada pedido
                .Include(p => p.Lineas)    // Incluir las líneas de pedido asociadas a cada pedido
                .ToList();
        }


        public Pedido FindById(int id)
        {
            return Contexto.Pedidos.Find(id);
        }

        public double ObtenerImporteTotalPedido(int id)
        {
            Pedido pedido = Contexto.Pedidos
                                .Include(p => p.Cliente)
                                .Include(p => p.Lineas)
                                .FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                return pedido.CalcularTotalConRecargo();
            }
            else
            {
                throw new Exception("No se encuentra pedido");
            }
        }

    }
}
