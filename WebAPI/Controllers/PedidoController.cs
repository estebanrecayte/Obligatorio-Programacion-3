using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public ICUObtenerListadoAnulados CUObtenerListado { get; set; }

        public PedidoController(ICUObtenerListadoAnulados cUListado)
        {
           CUObtenerListado = cUListado;
        }

        [HttpGet("Anulados")]
        public IActionResult Get()
        {
            List<Pedido> pedidosAnulados = CUObtenerListado.PedidosAnulados();
            return Ok(pedidosAnulados);
        }
    }
}
