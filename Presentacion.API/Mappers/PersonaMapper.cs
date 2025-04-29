using Dominio.Entidades;
using Presentacion.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Mappers
{
    public static class PersonaMapper
    {
        public static Persona ConvertirDtoAPersona(PersonaDTO dto)
        {
            return new Persona(dto.Nombre, dto.Apellido1, dto.Apellido2, dto.Correo);
        }

        public static PersonaRespuestaDTO ConvertirPersonaADto(Persona persona)
        {
            return new PersonaRespuestaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
                Correo = persona.Correo
            };
        }
    }
}
