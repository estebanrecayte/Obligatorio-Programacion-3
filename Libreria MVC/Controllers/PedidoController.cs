using DTOs;
using Libreria_MVC.Models;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{

    public class PedidoController : Controller
    {
        public ICUAlta<PedidoDTO> CUAlta { get; set; }

        public ICUBaja<Pedido> CUBaja { get; set; }

        //public ICUAlta<Linea> CUAltaLinea { get; set; }
        public ICUListado<Pedido> CUListado { get; set; }

        public ICUObtenerImporteTotalPedido CUObtenerTotal { get; set; }
        public ICUObtenerListadoAnulados CUObtenerListadoAnulados { get; set; }
        public ICUBuscarPorId<Pedido> CUBuscarPedido { get; set; }
        public ICUListado<Articulo> CUListadoArticulo { get; set; }
        //public ICUListado<Linea> CUListadoLinea { get; set; }
        public ICUListado<Cliente> CUListadoCliente { get; set; }
        
        public ICUBuscarPedidoPorFecha CUListadoPorFecha { get; set; }
        public ICUBuscarArticuloPorCodigo CUBuscarArticuloPorCodigo { get; set; }
        public ICUModificar<Pedido> CUModificar { get; set; }
        public PedidoController(ICUListado<Pedido> cUListado, ICUObtenerImporteTotalPedido cUObtenerTotal,
            ICUBuscarPorId<Pedido> cUBuscarPedido, ICUAlta<PedidoDTO> cUAlta, ICUBaja<Pedido> cUBaja
            /*ICUAlta<Linea> cUAltaLinea*/, ICUListado<Articulo> cUListadoArticulo,
            ICUListado<Cliente> cUListadoCliente/*, ICUListado<Linea> cUListadoLinea*/,
            ICUBuscarPedidoPorFecha cUListadoPorFecha = null,
            ICUModificar<Pedido> cUModificar = null, ICUObtenerListadoAnulados cUObtenerListadoAnulados = null, ICUBuscarArticuloPorCodigo cUBuscarArticuloPorCodigo = null)
        {
            CUListado = cUListado;
            CUObtenerTotal = cUObtenerTotal;
            CUBuscarPedido = cUBuscarPedido;
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            //CUAltaLinea = cUAltaLinea;
            CUListadoArticulo = cUListadoArticulo;
            CUListadoCliente = cUListadoCliente;
            //CUListadoLinea = cUListadoLinea;
            CUListadoPorFecha = cUListadoPorFecha;
            CUModificar = cUModificar;
            CUObtenerListadoAnulados = cUObtenerListadoAnulados;
            CUBuscarArticuloPorCodigo = cUBuscarArticuloPorCodigo;
        }

        private static List<Pedido> pedidosAnulados = new List<Pedido>();

        // GET: PedidoController
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListado.ObtenerListado();
                return View(pedidos);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: PedidoController/Create
        public ActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                AltaPedidoViewModel vm = new AltaPedidoViewModel
                {
                    Clientes = CUListadoCliente.ObtenerListado(),
                    Articulos = CUListadoArticulo.ObtenerListado()
                };

                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaPedidoViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PedidoDTO dto = new PedidoDTO()
                    {
                        Fecha = DateTime.Now,
                        IdCliente = vm.IdClienteSeleccionado,
                        CodigoProducto = vm.CodigoArticuloSeleccionado,
                        CantidadProducto = vm.CantidadSeleccionada,
                        FechaEntregaPrometida = vm.FechaEntregaPrometida,
                        TipoPedido = vm.TipoPedido,
                        Estado = true,
                    };


                    CUAlta.Alta(dto);


                    return RedirectToAction("Index");
                }
            }
            catch (ExcepcionPropiaException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
            }


            vm.Articulos = CUListadoArticulo.ObtenerListado();
            vm.Clientes = CUListadoCliente.ObtenerListado();
            return View(vm);
        }


        public ActionResult ObtenerImporte()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListado.ObtenerListado();
                ViewBag.ImporteTotal = 0;
                return View(pedidos);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult ObtenerImporte(int id)
        {
            try
            {
                double importeTotal = CUObtenerTotal.ObtenerImporteTotalPedido(id);
                ViewBag.ImporteTotal = importeTotal;
                return View("ObtenerImporte", CUListado.ObtenerListado());
            }
            catch (ExcepcionPropiaException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
            }
            return View("ObtenerImporte");
        }

        public ActionResult PedidosPorFecha()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListado.ObtenerListado();

                return View(pedidos);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult PedidosPorFecha(DateTime fechaEmision)
        {
            try
            {
                List<Pedido> pedidosFecha = CUListadoPorFecha.FindByFechaEmision(fechaEmision);
                if (pedidosFecha.Count == 0) {
                    ViewBag.Mensaje = "No hay pedidos en esta fecha";
                }
                return View(pedidosFecha);
            }
            catch (ExcepcionPropiaException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
            }
            
            return View("PedidosPorFecha");

        }


        public ActionResult AnularPedido()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidosAnulados = CUObtenerListadoAnulados.PedidosAnulados();

                return View(pedidosAnulados);

                
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult AnularPedido(int id)
        {
            try
            {
                Pedido pedidoAnulado = CUBuscarPedido.Buscar(id);
                if (pedidoAnulado != null)
                {
                    pedidoAnulado.Estado = false;
                    CUModificar.Modificar(pedidoAnulado);

                    List<Pedido> pedidosAnulados = CUObtenerListadoAnulados.PedidosAnulados();
                    return View("AnularPedido", pedidosAnulados);
                }
                else
                {
                    ViewBag.Mensaje = "El pedido no existe";
                    return View("Index");
                }
            }
            catch (ExcepcionPropiaException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
            }
            return View("Index");

        }

        public ActionResult AgregarProducto()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListado.ObtenerListado();
                List<Articulo> articulos = CUListadoArticulo.ObtenerListado();
                ViewBag.Articulos = articulos;

                var viewModel = new AgregarProductoViewModel();
                return View(viewModel);


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult AgregarProducto(int id,AgregarProductoViewModel viewModel)
        {
            try
            {
                Pedido pedidoAgregar = CUBuscarPedido.Buscar(id);
                if (pedidoAgregar != null)
                {
                    Articulo articulo = CUBuscarArticuloPorCodigo.BuscarArticuloPorCodigo(viewModel.IdArticulo);
                    if (articulo != null)
                    {
                        Linea nuevaLinea = new Linea
                        {
                            ArticuloId = articulo.Codigo,
                            Articulo = articulo,
                            Cantidad = viewModel.Cantidad,
                            PrecioUnitario = articulo.Precio,
                        };
                        pedidoAgregar.Lineas.Add(nuevaLinea);
                        pedidoAgregar.Precio = CUObtenerTotal.ObtenerImporteTotalPedido(id);
                        CUModificar.Modificar(pedidoAgregar);
                        List<Pedido> pedidos = CUListado.ObtenerListado();
                        var actualizadoViewModel = new AgregarProductoViewModel();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Mensaje = "El artículo seleccionado no existe.";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Error al cargar producto";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error al agregar el producto al pedido: " + ex.Message;
                return View("Index");
            }
        }






    }
}
