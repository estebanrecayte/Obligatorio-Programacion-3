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

        public static List<ArticuloDTO> ToListDto(List<Articulo> articulos)
        {
            return articulos.Select(articulo => new ArticuloDTO()
            {
                Codigo = articulo.Codigo,
                Nombre = articulo.Nombre,
                Descripcion =articulo.Descripcion, 
                Stock = articulo.Stock, 
                Precio = articulo.Precio
            })
            .ToList();
        }
    }
}
