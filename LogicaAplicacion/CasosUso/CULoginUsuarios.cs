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
    public class CULoginUsuarios : ICULoginUsuarios
    {
        public IRepositorioUsuario Repo { get; set; }
        public CULoginUsuarios(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public UsuarioDTO Login(string mail, string password)
        {
            Usuario usuario = Repo.Login(mail, password);
            if (usuario == null)
            {
                throw new ExcepcionPropiaException("El Usuario no existe, verificar credenciales");
            }
            return MapperUsuarios.ToDTOUsuario(usuario);


        }
    }
}
