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
    public class CUModificarUsuario : ICUModificar<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUModificarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public void Modificar(Usuario obj)
        {
            Usuario usuarioRepo = Repo.FindById(obj.Id);
            if (usuarioRepo == null)
            {
                throw new ExcepcionPropiaException("El usuario no existe en el repositorio.");
            }
            obj.Email = usuarioRepo.Email;
            obj.SetPassword(obj.Password);
            Repo.Update(obj);
        }
    }
}
