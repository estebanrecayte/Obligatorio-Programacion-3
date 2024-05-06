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
    public class RepositorioClienteEF : IRepositorioCliente
    {

        public LibreriaContext Contexto { get; set; }

        public RepositorioClienteEF(LibreriaContext ctx)
        {
            Contexto = ctx;

        }
        public void Add(Cliente obj)
        {
            if (Contexto.Clientes.Any(c => c.RazonSocial == obj.RazonSocial))
            {
                throw new DatosInvalidosException("Ya existe un cliente con la misma razon social");
            }

            if (Contexto.Clientes.Any(c => c.Rut == obj.Rut))
            {
                throw new DatosInvalidosException("Ya existe un cliente con el mismo RUT");
            }
            obj.EsValido();
            Contexto.Clientes.Add(obj);
            Contexto.SaveChanges();
        }

        public List<Cliente> FindAll()
        {
            return Contexto.Clientes.Include(cliente => cliente.Direccion).ToList();
        }

        public Cliente FindById(int id)
        {
            return Contexto.Clientes.Find(id);
        }

        public void Remove(int id)
        {
            Cliente aBorrar = FindById(id);
            if (aBorrar != null)
            {
                Contexto.Clientes.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new Exception("No existe el cliente a borrar");
            }
        }

        public void Update(Cliente obj)
        {
            obj.EsValido();
            Contexto.Clientes.Update(obj);
            Contexto.SaveChanges();
        }

        public List<Cliente> BuscarClientePorNombre(string nombre)
        {
            return Contexto.Clientes.Where(cliente => cliente.RazonSocial.Contains(nombre)).ToList();
        }

        public List<Cliente> ClientesConPedidosMayoresA(double precio)
        {
            // Obtener todos los pedidos y luego filtrar en memoria
            var pedidos = Contexto.Pedidos
                .Include(p => p.Cliente)   // Incluir el cliente asociado a cada pedido
                .Include(p => p.Lineas)    // Incluir las líneas de pedido asociadas a cada pedido
                .ToList();

            // Filtrar en memoria los pedidos cuyo total con recargo sea mayor que el precio dado
            var PedidosMayoresA = pedidos
                .Where(p => p.CalcularTotalConRecargo() > precio)
                .Select(p => p.Cliente.Id)
                .Distinct()
                .ToList();


            // Se busca en la base de datos clientes que tengan mismo id encontrado en la anterior
            var clientesConPedidosMayoresA = Contexto.Clientes
                .Where(cliente => PedidosMayoresA.Contains(cliente.Id))
                .ToList();

            return clientesConPedidosMayoresA;

        }

    }
}
