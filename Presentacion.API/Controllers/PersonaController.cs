using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicio _personaServicio;

        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPersona(Persona persona)
        {
            var resultado = await _personaServicio.RegistrarPersona(persona);

            if (resultado)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPersonas()
        {

            var personas = await _personaServicio.ObtenerPersonas();
            return Ok(personas);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarInformacion(int idPersona, string nombre, string apellido1, string apellido2, string correo)
        {
            var resultado = await _personaServicio.ActualizarDatosPersona(idPersona, nombre, apellido1, apellido2, correo);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpGet("{idPersona}")]
        public async Task<IActionResult> ObtenerPersonaPorId(int idPersona)
        {
            var persona = await _personaServicio.BuscarPersonaPorId(idPersona);

            if (persona != null)
                return Ok(persona);

            return Ok("No se encontró la persona con ese ID");
        }

        [HttpDelete("{idPersona}")]
        public async Task<IActionResult> EliminarPersona(int idPersona)
        {
            var resultado = await _personaServicio.EliminarPersona(idPersona);

            if (resultado)
                return Ok(true);
            
            return Ok(false);
        }



    }
}
