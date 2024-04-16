using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuarioPorMail(string mail)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario ojt)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
