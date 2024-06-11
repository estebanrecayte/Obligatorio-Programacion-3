using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoStockController : ControllerBase
    {
        public ICUAlta<TipoMovimientoStockDTO> CUAlta { get; set; }
        public ICUBaja<TipoMovimientoStockDTO> CUBaja { get; set; }
        public ICUBuscarPorId<TipoMovimientoStockDTO> CUBuscarTipoPorId { get; set; }
        public ICUListado<TipoMovimientoStockDTO> CUListado { get; set; }
        public ICUModificar<TipoMovimientoStockDTO> CUModificar { get; set; }

        public TipoMovimientoStockController(ICUAlta<TipoMovimientoStockDTO> cUAlta, ICUBaja<TipoMovimientoStockDTO> cUBaja, ICUBuscarPorId<TipoMovimientoStockDTO> cUBuscarTemaPorId, ICUListado<TipoMovimientoStockDTO> cUListado, ICUModificar<TipoMovimientoStockDTO> cUModificar)
        {
            CUAlta = cUAlta;
            CUBaja = cUBaja;
            CUBuscarTipoPorId = cUBuscarTemaPorId;
            CUListado = cUListado;
            CUModificar = cUModificar;
        }
        //api/tipomovimientostock/
        //Verbo: GET
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoMovimientoStockDTO> tipos = CUListado.ObtenerListado();
            return Ok(tipos);
        }


        //api/tipomovimientostock/5
        //Verbo: DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un entero positivo");

            try
            {
                TipoMovimientoStockDTO aBorrar = CUBuscarTipoPorId.Buscar(id);
                if (aBorrar == null) return NotFound("El tipo de movimiento con id " + id + " no existe");
                CUBaja.Baja(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //api/tipomovimientostock/5
        //Verbo: PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoMovimientoStockDTO? aModificar)
        {
            if (id <= 0) return BadRequest("El id debe ser un entero positivo");
            if (aModificar == null) return BadRequest("No se proporcionaron datos para la modificación");
            if (id != aModificar.Id) return BadRequest("Se proporcionaron dos id de tipos de movimientos diferentes");

            try
            {
                CUModificar.Modificar(aModificar);
                return Ok(aModificar);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor. Reintente más tarde.");
            }
        }


        //api/tipomovimientostock/5
        //Verbo: GET
        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult Get(int id)
        {
            //sentinela
            if (id <= 0) return BadRequest("El id del tipo de movimiento deber ser un entero positivo");

            TipoMovimientoStockDTO buscado = CUBuscarTipoPorId.Buscar(id);

            //sentinela
            if (buscado == null) return NotFound("El tipo de movimiento con id " + id + " no existe");

            return Ok(buscado);
        }

        //api/tipomovimientostock/
        //Verbo: POST
        [HttpPost]
        public IActionResult Post([FromBody] TipoMovimientoStockDTO tipoDTO)
        {

            if (tipoDTO == null) return BadRequest("No se proporcionaron datos para el alta");

            try
            {
                CUAlta.Alta(tipoDTO);
                return CreatedAtRoute("BuscarPorId", new { id = tipoDTO.Id }, tipoDTO);
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
    }
}

