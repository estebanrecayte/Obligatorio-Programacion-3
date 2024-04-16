using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        public ICUListado<Usuario> CUListado { get; set; }


        public UsuarioController(ICUListado<Usuario> cuListado)
        {

            CUListado = cuListado;

        }
        public IActionResult Index()
        {
            List<Usuario> usuarios = CUListado.ObtenerListado();
            return View(usuarios);
        }
    }
}
