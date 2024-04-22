using Libreria_MVC.Models;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Libreria_MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public ICULogin CULogin { get; set; }


        public HomeController (ICULogin cuLogin)
        {

            CULogin = cuLogin;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                
                bool isValid = CULogin.UsuarioCorrecto(usuario.Mail, usuario.Password);

                if (isValid)
                {
                    HttpContext.Session.SetString("Rol", "Adm");
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    ViewBag.Mensaje = "Credenciales incorrectas";
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }

            return View(usuario);
        }


    }
}
