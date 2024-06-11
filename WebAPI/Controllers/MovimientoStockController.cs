using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoStockController : ControllerBase
    {
        public ICUAlta<MovimientoStockDTO> CUAlta { get; set; }
        public ICUBaja<MovimientoStockDTO> CUBaja { get; set; }
        public ICUBuscarPorId<MovimientoStockDTO> CUBuscarMovimientoPorId { get; set; }
        public ICUListado<MovimientoStockDTO> CUListado { get; set; }
        public ICUModificar<MovimientoStockDTO> CUModificar { get; set; }
        public ICUListado<ArticuloDTO> CUListadoArticulos { get; set; }

        public MovimientoStockController(ICUAlta<MovimientoStockDTO> cUAlta, ICUBaja<MovimientoStockDTO> cUBaja, ICUBuscarPorId<MovimientoStockDTO> cUBuscarMovimientoPorId, ICUListado<MovimientoStockDTO> cUListado, ICUModificar<MovimientoStockDTO> cUModificar, ICUListado<ArticuloDTO> cUListadoArticulos)
        {
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            CUBuscarMovimientoPorId = cUBuscarMovimientoPorId;
            CUListado = cUListado;
            CUModificar = cUModificar;
            CUListadoArticulos = cUListadoArticulos;
        }
        // GET: api/MovimientoStock
        [HttpGet]
        public IActionResult Get()
        {
            List<MovimientoStockDTO> movimientos = CUListado.ObtenerListado();
            return Ok(movimientos);
        }

        // GET: api/MovimientoStock/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                MovimientoStockDTO movimiento = CUBuscarMovimientoPorId.Buscar(id);
                if (movimiento == null)
                {
                    return NotFound();
                }
                return Ok(movimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/MovimientoStock
        [HttpPost]
        public IActionResult Post([FromBody] MovimientoStockDTO movimiento)
        {
            try          
            {
                if (movimiento == null)
                {
                    return BadRequest("Datos Incorrectos");
                }
                if (movimiento.Id != 0)
                {
                    return BadRequest("El id del movimiento debe ser diferente de 0");
                }
                if (movimiento.TipoMovimientoStockId < 0)
                {
                    return BadRequest("Selecionar tipo de movimiento valido");
                }
                if (movimiento.ArticuloId < 0)
                {
                    return BadRequest("Selecionar un articulo valido");
                }
                if (movimiento.Cantidad < 0)
                {
                    return BadRequest("La cantidad seleccionada debe ser positiva");
                }
                CUAlta.Alta(movimiento);
                return CreatedAtAction(nameof(Get), new { id = movimiento.Id }, movimiento);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/MovimientoStock/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovimientoStockDTO movimiento)
        {
            try
            {
                if (id != movimiento.Id)
                {
                    return BadRequest("ID del movimiento no coincide con el ID proporcionado");
                }
                CUModificar.Modificar(movimiento);
                return NoContent();
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/MovimientoStock/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CUBaja.Baja(id);
                return NoContent();
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // GET: api/MovimientoStock/Articulos
        [HttpGet("Articulos")]
        public IActionResult GetArticulos()
        {
            try
            {
                List<ArticuloDTO> articulos = CUListadoArticulos.ObtenerListado();
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
    
