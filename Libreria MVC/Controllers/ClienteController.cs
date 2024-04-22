using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
    public class ClienteController : Controller
    {

        public ICUListado<Cliente> CUListado { get; set; }
        public ICUAlta<ClienteDTO> CUAlta { get; set; }
        public ICUBaja<Cliente> CUBaja { get; set; }
        public ICUModificar<Cliente> CUModificar { get; set; }
        
        public ICUBuscarClientePorNombre CUBuscarPorNombre { get; set; }

        public ClienteController(ICUListado<Cliente> cUListado, ICUAlta<ClienteDTO> cUAlta, ICUBaja<Cliente> cUBaja, ICUModificar<Cliente> cUModificar, ICUBuscarClientePorNombre cUBuscarPorNombre)
        {
            CUListado = cUListado;
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            CUModificar = cUModificar;
            CUBuscarPorNombre = cUBuscarPorNombre;
        }




        // GET: ClienteController
        public ActionResult Index()
        {
            return View(CUListado.ObtenerListado());
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
    }
}
