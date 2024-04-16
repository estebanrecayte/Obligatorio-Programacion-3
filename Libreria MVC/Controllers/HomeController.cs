using Libreria_MVC.Models;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Libreria_MVC.Controllers
{
    public class HomeController : Controller
    {

        public ICULogin CULogin { get; set; }


        public HomeController (ICULogin cuLogin)
        {

            CULogin = cuLogin;

        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isValid = CULogin.UsuarioCorrecto(model.Mail, model.Password);

                    if (isValid)
                    {

                        return RedirectToAction("Index","Usuario");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Credenciales incorrectas";
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
            }

            return View(model);
        }

    }
}
