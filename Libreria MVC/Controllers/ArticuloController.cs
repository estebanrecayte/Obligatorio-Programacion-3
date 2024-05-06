using DTOs;
using Libreria_MVC.Models;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
    
    public class ArticuloController : Controller
    {
        public ICUListado<Articulo> CUListado { get; set; }
        public ICUAlta<ArticuloDTO> CUAlta { get; set; }

        public ArticuloController(ICUListado<Articulo> cUListado, ICUAlta<ArticuloDTO> cUAlta)
        {
            CUListado = cUListado;
            CUAlta = cUAlta;
        }




        // GET: ArticuloController
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                List<Articulo> articulos = CUListado.ObtenerListado();
                return View(articulos);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }    
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
            {
                AltaArticuloViewModel vm = new AltaArticuloViewModel();

                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaArticuloViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ArticuloDTO dto = new ArticuloDTO()
                    {
                        Nombre = vm.Nombre,
                        Descripcion = vm.Descripcion,
                        Codigo = vm.Codigo,
                        Precio = vm.Precio,
                        Stock = vm.Stock
                    };

                    CUAlta.Alta(dto);

                    return RedirectToAction("Index", "Usuario");
                }
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado al crear el articulo";
            }
            return View(vm);
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
