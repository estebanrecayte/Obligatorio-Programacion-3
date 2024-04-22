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
    public class RepositorioClienteEF : IRepositorioCliente
    {

        public LibreriaContext Contexto { get; set; }

        public RepositorioClienteEF(LibreriaContext ctx)
        {
            Contexto = ctx;

        }
        public void Add(Cliente obj)
        {
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

        public Cliente BuscarClientePorNombre(string nombre)
        {
            return Contexto.Clientes.FirstOrDefault(cliente => cliente.RazonSocial == nombre);
        }
    }
}
