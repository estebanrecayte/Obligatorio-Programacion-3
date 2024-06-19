using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuarios
    {
        public static UsuarioDTO ToDTOUsuario (Usuario usuario)
        {
            return new UsuarioDTO()
            {
                Email = usuario.Email,
                Password = usuario.Password,
                Rol = usuario.Rol,
            };
        }
    }
}
