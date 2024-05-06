using DTOs;
using Libreria_MVC.Models;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
   
    public class PedidoController : Controller
    {
        public ICUAlta<PedidoDTO> CUAlta { get; set; }

        public ICUBaja<Pedido> CUBaja { get; set; }

        public ICUAlta<Linea> CUAltaLinea { get; set; }
        public ICUListado<Pedido> CUListado { get; set; }

        public ICUObtenerImporteTotalPedido CUObtenerTotal {  get; set; }

        public ICUBuscarPorId<Pedido> CUBuscarPedido { get; set; }
        public ICUListado<Articulo> CUListadoArticulo { get; set; }
        public ICUListado<Linea> CUListadoLinea { get; set; }
        public ICUListado<Cliente> CUListadoCliente { get; set; }
        public PedidoController(ICUListado<Pedido> cUListado, ICUObtenerImporteTotalPedido cUObtenerTotal, 
            ICUBuscarPorId<Pedido> cUBuscarPedido, ICUAlta<PedidoDTO> cUAlta, ICUBaja<Pedido> cUBaja, 
            ICUAlta<Linea> cUAltaLinea, ICUListado<Articulo> cUListadoArticulo, ICUListado<Cliente> cUListadoCliente, ICUListado<Linea> cUListadoLinea)
        {
            CUListado = cUListado;
            CUObtenerTotal = cUObtenerTotal;
            CUBuscarPedido = cUBuscarPedido;
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            CUAltaLinea = cUAltaLinea;
            CUListadoArticulo = cUListadoArticulo;
            CUListadoCliente = cUListadoCliente;
            CUListadoLinea = cUListadoLinea;

        }

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
                    // Crear una nueva línea de pedido con la cantidad seleccionada
                    Linea nuevaLinea = new Linea
                    {
                        Articulo = new Articulo { Codigo = vm.CodigoArticuloSeleccionado }, // Asignar el artículo seleccionado a la línea
                        Cantidad = vm.CantidadSeleccionada, // Asignar la cantidad seleccionada a la línea
                        PrecioUnitario = 0 // Puedes obtener el precio unitario del artículo desde la base de datos si es necesario
                    };

                    // Agregar la nueva línea a la lista de líneas del ViewModel
                    vm.Lineas.Add(nuevaLinea);

                    // Crear el DTO del pedido con los datos del ViewModel
                    PedidoDTO dto = new PedidoDTO()
                    {
                        Fecha = DateTime.Now,
                        IdCliente = vm.IdClienteSeleccionado,
                        Lineas = vm.Lineas, // Asignar las líneas al pedido
                        FechaEntregaPrometida = vm.FechaEntregaPrometida,
                        TipoPedido = vm.TipoPedido,
                    };

                    // Llamar al método de creación del pedido en la capa de negocio
                    CUAlta.Alta(dto);

                    // Redirigir al usuario a la página de índice después de crear el pedido
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }

            // Si hay un error o el modelo no es válido, recargar la lista de clientes y artículos y volver a mostrar el formulario
            vm.Articulos = CUListadoArticulo.ObtenerListado();
            vm.Clientes = CUListadoCliente.ObtenerListado();
            return View(vm);
        }



        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerImporte()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListado.ObtenerListado();
                ViewBag.ImporteTotal = 0;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult ObtenerImporte(int id)
        {

            double importeTotal = CUObtenerTotal.ObtenerImporteTotalPedido(id);
            ViewBag.ImporteTotal = importeTotal;
            return View("ObtenerImporte", CUListado.ObtenerListado());

        }
    }
}
