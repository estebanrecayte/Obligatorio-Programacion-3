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
        public ICUListado<ArticuloDTO> CUListadoArticulo { get; set; }

        public ICUAlta<ArticuloDTO> CUAlta { get; set; }

        public ArticuloController(ICUListado<ArticuloDTO> cUListado, ICUAlta<ArticuloDTO> cUAlta)
        {
            CUListadoArticulo = cUListado;
            CUAlta = cUAlta;
        }


        //api/articulo/
        [HttpGet]
        public IActionResult Get()
        {
            List<ArticuloDTO> articulos = CUListadoArticulo.ObtenerListado();
            return Ok(articulos);
        }
    }
}
