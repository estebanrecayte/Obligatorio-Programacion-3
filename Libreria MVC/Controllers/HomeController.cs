using Libreria_MVC.Models;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Cryptography;
using LogicaAplicacion.CasosUso;

namespace Libreria_MVC.Controllers
{
    public class HomeController : Controller
    {

        public ICULogin CULogin { get; set; }


        public HomeController(ICULogin cuLogin)
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
            catch (ExcepcionPropiaException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
            }

            return View(usuario);
        }

        private string GetSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
