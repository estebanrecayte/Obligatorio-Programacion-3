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
    public class CUModificarPedido : ICUModificar<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUModificarPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Modificar(Pedido obj)
        {

                        {
                Repo.Update(obj);
            }
            //try
            //{
            //    Pedido pedidoExistente = Repo.FindById(obj.Id);
            //    if (pedidoExistente == null)
            //    {
            //        throw new ExcepcionPropiaException("El pedido no existe.");
            //    }
            //    //pedidoExistente.FechaEntregaPrometida = obj.FechaEntregaPrometida;
            //    Repo.Update(pedidoExistente);
            //}
            //catch (Exception ex)
            //{
            //    throw new ExcepcionPropiaException("Error al modificar el pedido");
            //}
        }
    }
}
