using DTOs;
using Libreria_MVC.Models;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        public ICUListado<Usuario> CUListado { get; set; }
        public ICUAlta<UsuarioDTO> CUAlta { get; set; }

        public ICUBaja<Usuario> CUBaja { get; set; }
        public ICUModificar<Usuario> CUModificar { get; set; }
        public ICUBuscarPorId<Usuario> CUBuscar { get; set; }


        public UsuarioController(ICUListado<Usuario> cuListado, ICUAlta<UsuarioDTO> cuAlta, ICUBuscarPorId<Usuario> cUBuscar, ICUModificar<Usuario> cUModificar, ICUBaja<Usuario> cUBaja)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUBuscar = cUBuscar;
            CUModificar = cUModificar;
            CUBaja = cUBaja;
        }
        public IActionResult Index()
        {
            var rol = HttpContext.Session.GetString("Rol");
            List<Usuario> usuarios = CUListado.ObtenerListado();
            ViewBag.Rol = rol;
            return View(usuarios);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Rol");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Create()
        {
            AltaUsuarioViewModel vm = new AltaUsuarioViewModel();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioDTO dto = new UsuarioDTO()
                    {
                        Email = vm.Email,
                        Nombre = vm.Nombre,
                        Apellido = vm.Apellido,
                        Password = vm.Password
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
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }
            return View(vm);
        }

        // GET: AutoresController/Details/5
        public ActionResult Details(int id)
        {
            Usuario a = CUBuscar.Buscar(id);
            return View(a);
        }

        public ActionResult Edit(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // POST: TemasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario u)
        {
            try
            {
                CUModificar.Modificar(u);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. El alta no se realizó";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // POST: TemasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario u)
        {
            try
            {
                CUBaja.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }
    }
}
