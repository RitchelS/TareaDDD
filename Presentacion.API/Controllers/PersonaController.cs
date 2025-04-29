using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.API.Dtos;
using Presentacion.Mappers;

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
        public async Task<IActionResult> RegistrarPersona(PersonaDTO persona)
        {
            var resultado = await _personaServicio.RegistrarPersona(PersonaMapper.ConvertirDtoAPersona(persona));

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
            var personasDto = personas.Select(p => PersonaMapper.ConvertirPersonaADto(p));

            return Ok(personasDto);
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
            {
                var personaDto = PersonaMapper.ConvertirPersonaADto(persona);
                return Ok(personaDto);
            }

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
