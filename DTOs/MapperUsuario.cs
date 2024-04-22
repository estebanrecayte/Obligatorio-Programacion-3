using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuario
    {
        public static Usuario ToUsuario(UsuarioDTO dto)
        {
            Usuario a = new Usuario()
            {
                Nombre = new NombreUsuario(dto.Nombre),
                Email = dto.Email,
                Password = dto.Password,
                Apellido = dto.Apellido,
            };
            return a;
        }
    }
}
