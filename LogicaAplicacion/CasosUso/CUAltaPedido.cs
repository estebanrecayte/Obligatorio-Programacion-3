using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
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
        public IRepositorioPedido RepoPedidos { get; set; }
        public IRepositorioArticulo RepoArticulos { get; set; }
        public IRepositorioCliente RepoClientes { get; set; }

        public CUAltaPedido(IRepositorioPedido repoPedidos, IRepositorioArticulo repoArticulos, IRepositorioCliente repoClientes)
        {
            RepoPedidos = repoPedidos;
            RepoArticulos = repoArticulos;
            RepoClientes = repoClientes;

        }
        public void Alta(PedidoDTO obj)
        {
            Articulo articulo = RepoArticulos.GetByCodigo(obj.CodigoProducto);
            Cliente nuevoCliente = RepoClientes.FindById(obj.IdCliente);

            if (articulo.Stock >= obj.CantidadProducto)
            {
                Pedido nuevoPedido;
                Linea nuevaLinea = new Linea
                {
                    Articulo = articulo,
                    PrecioUnitario = articulo.Precio,
                    Cantidad = obj.CantidadProducto,
                    ArticuloId = obj.CodigoProducto,

                };
                

                if (obj.TipoPedido == "Comun")
                {
                    if (obj.FechaEntregaPrometida < DateTime.Now.AddDays(7))
                    {
                        throw new ExcepcionPropiaException("La fecha de entrega prometida para pedidos comunes no puede ser menor a una semana");
                    }
                    nuevoPedido = MapperPedido.ToPedidoComun(obj);
                    
                    

                }
                else if (obj.TipoPedido == "Express")
                {

                    if (obj.FechaEntregaPrometida > DateTime.Now.AddDays(5)) 
                    {
                        throw new ExcepcionPropiaException("La fecha de entrega prometida para pedidos express no puede ser superior a 5 días");
                    }
                    nuevoPedido = MapperPedido.ToPedidoExpress(obj);


                }
                else
                {
                    throw new ExcepcionPropiaException("Tipo de pedido no válido");
                }

                if (nuevoPedido != null)
                {
                    nuevoPedido.Cliente = nuevoCliente;
                    nuevoPedido.Lineas = new List<Linea>();
                    nuevoPedido.Lineas.Add(nuevaLinea);
                    nuevoPedido.Precio = nuevoPedido.CalcularTotalConRecargo();
                    RepoPedidos.Add(nuevoPedido);
                }
                else
                {
                    throw new ExcepcionPropiaException("No se pudo hacer el alta de pedido, porque el cliente no existe");
                }
            }
            else
            {
                throw new ExcepcionPropiaException("No hay suficiente stock del articulo seleccionado");
            }




        }
    }
}
