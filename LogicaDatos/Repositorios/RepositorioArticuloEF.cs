using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioArticuloEF : IRepositorioArticulo
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioArticuloEF(LibreriaContext ctx)
        {
            Contexto = ctx;

        }

        public void Add(Articulo obj)
        {
            if (Contexto.Articulos.Any(a => a.Codigo == obj.Codigo))
            {
                throw new DatosInvalidosException("Ya existe un articulo con el mismo codigo");
            }
            else if (Contexto.Articulos.Any(a => a.Nombre == obj.Nombre))
            {
                throw new DatosInvalidosException("Ya existe un articulo con el mismo nombre");
            }
            obj.EsValido();
            Contexto.Add(obj);
            Contexto.SaveChanges();
        }

        public void Remove(int id)
        {
            Articulo aBorrar = Contexto.Articulos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Articulos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionPropiaException("El articulo no existe");
            }
        }

        public void Update(Articulo obj)
        {
            obj.EsValido();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        public List<Articulo> FindAll()
        {
            return Contexto.Articulos.OrderBy(a=>a.Nombre).ToList();
        }

        public Articulo FindById(long id)
        {
            return Contexto.Articulos.Find(id);
        }

        public Articulo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Articulo GetByCodigo(long codigo)
        {
            return Contexto.Articulos.FirstOrDefault(a => a.Codigo == codigo);
        }
    }
}
