using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class MovimientoStockController : ControllerBase
    {
        public ICUAlta<MovimientoStockDTO> CUAlta { get; set; }
        public ICUBuscarPorId<MovimientoStockDTO> CUBuscarMovimientoPorId { get; set; }
        public ICUListado<MovimientoStockDTO> CUListado { get; set; }
        public ICUListado<ArticuloDTO> CUListadoArticulos { get; set; }

        public ICUCantidadTotalMovimientoStock CUCantidadTotalMovimientos {  get; set; }

        public ICUMovimientosAMostrarPorPagina CUMovimientosAMostrarPorPagina { get; set; }

        public ICUObtenerArticulosConMovimientosEntreFechas CUObtenerArticulosConMovimientosEntreFechas { get; set; }

        public ICUObtenerMovimientosPorArticuloYTipo CUObtenerMovimientosPorArticuloYTipo { get; set; }

        public ICUResumenCantidadMovida CUResumenCantidadMovida { get; set; }

        public MovimientoStockController(ICUAlta<MovimientoStockDTO> cUAlta, ICUBuscarPorId<MovimientoStockDTO> cUBuscarMovimientoPorId, 
            ICUListado<MovimientoStockDTO> cUListado, 
             ICUListado<ArticuloDTO> cUListadoArticulos,
            ICUCantidadTotalMovimientoStock cUCantidadTotalMovimientoStock, ICUMovimientosAMostrarPorPagina cUMovimientosAMostrarPorPagina,
            ICUObtenerArticulosConMovimientosEntreFechas cUObtenerArticulosConMovimientosEntreFechas, ICUObtenerMovimientosPorArticuloYTipo cUObtenerMovimientosPorArticuloYTipo,
            ICUResumenCantidadMovida cUResumenCantidadMovida
            )
        {
            CUAlta = cUAlta;
            
            CUBuscarMovimientoPorId = cUBuscarMovimientoPorId;
            CUListado = cUListado;
            
            CUListadoArticulos = cUListadoArticulos;
            CUCantidadTotalMovimientos = cUCantidadTotalMovimientoStock;
            CUMovimientosAMostrarPorPagina = cUMovimientosAMostrarPorPagina;
            CUObtenerArticulosConMovimientosEntreFechas = cUObtenerArticulosConMovimientosEntreFechas;
            CUObtenerMovimientosPorArticuloYTipo = cUObtenerMovimientosPorArticuloYTipo;
            CUResumenCantidadMovida = cUResumenCantidadMovida;

        }
        // GET: api/MovimientoStock
        
        [HttpGet]
        [Authorize(Roles = "Encargado")]
        public IActionResult Get()
        {
            List<MovimientoStockDTO> movimientos = CUListado.ObtenerListado();
            return Ok(movimientos);
        }

        // GET: api/MovimientoStock/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize(Roles = "Encargado")]
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
        [Authorize(Roles = "Encargado")]
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
                if (movimiento.Cantidad <= 0)
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

        
        // GET: api/MovimientoStock/Articulos
        [HttpGet("Articulos")]
        [Authorize(Roles = "Encargado")]
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

        [HttpGet("CantidadPaginas")]
        
        public IActionResult CantidadTotalPaginas()
        {
            try
            {
                return Ok((double)CUCantidadTotalMovimientos.CantidadTotalDeMovimientos() / 2);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpGet("MovimientosPorPagina/{pagina}")]
        [Authorize(Roles = "Encargado")]

        public IActionResult MovimientosPorPagina(int pagina)
        {
            try
            {
                if (pagina == 0)
                {
                    return BadRequest("El número de página recibida no es correcta");
                }
                return Ok(CUMovimientosAMostrarPorPagina.MovimientosAMostrarPorPagina(pagina));
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }


        }
        [HttpGet("ArticulosConMovimientosEntreFechas")]
        [Authorize(Roles = "Encargado")]
        public IActionResult ObtenerArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin, int pagina)
        {
            try
            {
                if (pagina <= 0)
                {
                    return BadRequest("El número de página recibido no es válido");
                }

                var articulos = CUObtenerArticulosConMovimientosEntreFechas.ObtenerArticulosConMovimientosEntreFechas(fechaInicio, fechaFin, pagina);

                if (articulos.Count() == 0)
                {
                    return BadRequest("No hay articulos involucrados");
                }
                return Ok(articulos);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpGet("CantidadArticulosConMovimientosEntreFechas")]
        
        public IActionResult CantidadArticulosConMovimientosEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return Ok((double)CUObtenerArticulosConMovimientosEntreFechas.CantidadTotalArticulosConMovimientosEntreFechas(fechaInicio,fechaFin) / 2);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("MovimientosPorArticuloYTipo")]
        [Authorize(Roles = "Encargado")]
        public IActionResult ObtenerMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId, int pagina)
        {
            try
            {
                if (pagina <= 0)
                {
                    return BadRequest("El número de página recibido no es válido");
                }

                
                var movimientos = CUObtenerMovimientosPorArticuloYTipo.ObtenerMovimientosPorArticuloYTipo(articuloId, tipoMovimientoId, pagina);
                if (movimientos.Count() == 0)
                {
                    return BadRequest("No hay mas movimientos");
                }

                return Ok(movimientos);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpGet("CantidadMovimientosPorArticuloYTipo")]
        
        public IActionResult CantidadMovimientosPorArticuloYTipo(long articuloId, int tipoMovimientoId)
        {
            try
            {
                return Ok((double)CUObtenerMovimientosPorArticuloYTipo.ObtenerCantidadTotalMovimientosPorArticuloYTipo(articuloId, tipoMovimientoId) / 2);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("ResumenCantidadMovida")]
        [Authorize(Roles = "Encargado")]
        public IActionResult ObtenerResumenCantidadMovida()
        {
            try
            {
                List <ResumenMovimientoStockDTO> resumen = CUResumenCantidadMovida.ObtenerResumen();
                if (resumen == null)
                {
                    return NotFound();
                }
                if (resumen.Count == 0)
                {
                    return BadRequest("No hay informacion a mostrar");
                }
                return Ok(resumen);
            }
            catch (ExcepcionPropiaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
    
