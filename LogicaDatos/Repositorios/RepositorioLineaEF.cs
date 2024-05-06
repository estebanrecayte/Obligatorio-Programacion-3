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
    public class RepositorioLineaEF : IRepositorioLinea
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioLineaEF(LibreriaContext ctx)
        {
            Contexto = ctx;

        }

        public void Add(Linea obj)
        {
            obj.EsValido();
            Contexto.Add(obj);
            Contexto.SaveChanges();
        }

        public void Remove(int id)
        {
            Linea aBorrar = Contexto.Lineas.Find(id);
            if (aBorrar != null)
            {
                Contexto.Lineas.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new Exception("La linea no existe");
            }
        }

        public void Update(Linea obj)
        {
            obj.EsValido();
            Contexto.Lineas.Update(obj);
            Contexto.SaveChanges();
        }

        public List<Linea> FindAll()
        {
            return Contexto.Lineas
                   .Include(l => l.Articulo).ToList();
        }

        public Linea FindById(int id)
        {
            return Contexto.Lineas.Find(id);
        }
    }
}
