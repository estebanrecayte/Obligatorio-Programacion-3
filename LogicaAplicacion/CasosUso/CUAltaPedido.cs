using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaPedido : ICUAlta<PedidoDTO>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAltaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Alta(PedidoDTO obj)
        {
            Pedido nuevoPedido;

            if (obj.TipoPedido == "Comun")
            {
                nuevoPedido = MapperPedido.ToPedidoComun(obj);
            }
            else if (obj.TipoPedido == "Express")
            {
                nuevoPedido = MapperPedido.ToPedidoExpress(obj);
            }
            else
            {
                throw new ArgumentException("Tipo de pedido no válido");
            }

            Repo.Add(nuevoPedido);
        }
    }
}
