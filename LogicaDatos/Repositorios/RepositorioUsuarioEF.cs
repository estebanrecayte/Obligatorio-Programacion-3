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
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuarioEF(LibreriaContext ctx)
        {
            Contexto = ctx;
            
        }
        public void Add(Usuario obj)
        {
            if (Contexto.Usuarios.Any(u => u.Email == obj.Email))
            {
                throw new DatosInvalidosException("Ya existe un usuario con el mismo email");
            }
            obj.EsValido();
            Contexto.Add(obj);
            Contexto.SaveChanges();
        }

        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);

        }

        public void Remove(int id)
        {
            Usuario usuarioABorrar = Contexto.Usuarios.Find(id);
            if (usuarioABorrar != null) { 
                Contexto.Remove(usuarioABorrar);
                Contexto.SaveChanges();
            }
            else {
                throw new ExcepcionPropiaException("No existe el usuario a borrar");
            }
        }

        public void Update(Usuario obj)
        {
            
            obj.EsValido();
            Contexto.Usuarios.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario BuscarUsuarioPorMail(string mail)
        {
            return Contexto.Usuarios.FirstOrDefault(u => u.Email == mail);
        }

        
    }
}
