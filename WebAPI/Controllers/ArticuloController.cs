using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso;
using DTOs;
using LogicaNegocio.Dominio;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public ICUListado<Articulo> CUListado { get; set; }

        public ICUAlta<ArticuloDTO> CUAlta { get; set; }

        public ArticuloController(ICUListado<Articulo> cUListado, ICUAlta<ArticuloDTO> cUAlta)
        {
            CUListado = cUListado;
            CUAlta = cUAlta;
        }


        //api/articulo/
        [HttpGet]
        public IActionResult Get()
        {
            List<Articulo> articulos = CUListado.ObtenerListado();
            return Ok(articulos);
        }
    }
}
