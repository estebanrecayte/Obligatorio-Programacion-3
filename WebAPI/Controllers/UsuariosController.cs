﻿using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.ExcepcionPropias;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        public ICULoginUsuarios CULogin { get; set; }

        public UsuariosController(ICULoginUsuarios cuLogin)
        {
            CULogin = cuLogin;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                usuarioDTO = CULogin.Login(usuarioDTO.Email, usuarioDTO.Password);
                if (usuarioDTO == null)
                {
                    return NotFound("Datos incorrectos");
                }
                return Ok(new UsuarioLogueadoDTO()
                {
                    
                    Rol = usuarioDTO.Rol,
                    Token = Token.ManejadorToken.CrearToken(usuarioDTO)

                });
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
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
