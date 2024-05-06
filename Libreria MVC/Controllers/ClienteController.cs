using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
   
    public class ClienteController : Controller
    {

        public ICUListado<Cliente> CUListado { get; set; }

        public ICUListado<Pedido> CUListadoPedido { get; set; }
        public ICUAlta<ClienteDTO> CUAlta { get; set; }
        public ICUBaja<Cliente> CUBaja { get; set; }
        public ICUModificar<Cliente> CUModificar { get; set; }
        
        public ICUBuscarClientePorNombre CUBuscarPorNombre { get; set; }

        public ICUBuscarClientePorPedidoMayor CUBuscarPorImporte { get; set; }

        public ClienteController(ICUListado<Cliente> cUListado, 
            ICUAlta<ClienteDTO> cUAlta, ICUBaja<Cliente> cUBaja, 
            ICUModificar<Cliente> cUModificar, ICUBuscarClientePorNombre cUBuscarPorNombre, ICUBuscarClientePorPedidoMayor cUBuscarPorImporte, ICUListado<Pedido> cUListadoPedido)
        {
            CUListado = cUListado;
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            CUModificar = cUModificar;
            CUBuscarPorNombre = cUBuscarPorNombre;
            CUBuscarPorImporte = cUBuscarPorImporte;
            CUListadoPedido = cUListadoPedido;
        }




        // GET: ClienteController
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                return View(CUListado.ObtenerListado());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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

        public ActionResult BuscarPorNombre()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                return View(CUListado.ObtenerListado());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult BuscarPorNombre(string nombre)
        {
            List<Cliente> clientes = CUBuscarPorNombre.BuscarPorNombre(nombre);
            if (clientes.Count == 0) ViewBag.Mensaje = "No hay resultados";
            return View(clientes);
        }

        public ActionResult BuscarPorImporte()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Pedido> pedidos = CUListadoPedido.ObtenerListado();
                return View(CUListado.ObtenerListado());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult BuscarPorImporte(double precio)
        {
            List<Cliente> clientes = CUBuscarPorImporte.BuscarClientePorPedidoMayorA(precio);
            if (clientes.Count == 0) ViewBag.Mensaje = "No hay resultados";
            return View(clientes);
        }
    }
}
