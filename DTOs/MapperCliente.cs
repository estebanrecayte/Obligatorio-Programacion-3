using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperCliente
    {
        public static Cliente ToCliente(ClienteDTO dto)
        {
            Cliente a = new Cliente()
            {
                Direccion = new DireccionCliente(dto.Calle,dto.Numero,dto.Ciudad),
                Rut = dto.Rut,
                RazonSocial = dto.RazonSocial,
                DistanciaKm = dto.DistanciaKm,
            };
            return a;
        }
    }
}
