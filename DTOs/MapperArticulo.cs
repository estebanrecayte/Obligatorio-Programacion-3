using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperArticulo
    {
        public static Articulo ToArticulo(ArticuloDTO dto)
        {
            Articulo a = new Articulo()
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Stock = dto.Stock,
                Precio = dto.Precio,

            };
            return a;
        }
    }
}
