using Dominio.Entidades;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infraestuctura.Contexto;
using Infraestuctura.Entidades;

namespace Infraestuctura.Repositorios
{
    public class PersonaRepositorio : IPersonaRepositorio
    {

        private readonly ContextoDB _context;

        public PersonaRepositorio(ContextoDB context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDatosPersona(int idPersona, string nombre, string apellido1, string apellido2, string correo)
        {
            var entity = await _context.Personas.FindAsync(idPersona);

            if (entity == null)
                return false;

            entity.Nombre = nombre;
            entity.Apellido1 = apellido1;
            entity.Apellido2 = apellido2;
            entity.Correo = correo;

            _context.Personas.Update(entity);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }

        public async Task<Persona> BuscarPersonaPorId(int idPersona)
        {
            var entity = await _context.Personas.FindAsync(idPersona);

            if (entity == null)
                return null;

            return new Persona(entity.Nombre, entity.Apellido1, entity.Apellido2, entity.Correo)
            {
                IdPersona = entity.IdPersona
            };
        }

        public async  Task<bool> EliminarPersona(int idPersona)
        {
            var entity = await _context.Personas.FindAsync(idPersona);

            if (entity == null)
                return false;

            _context.Personas.Remove(entity);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonas()
        {
           
            var entidades = await _context.Personas.ToListAsync();

            return entidades.Select(p => new Persona(p.Nombre, p.Apellido1, p.Apellido2, p.Correo)
            {
                IdPersona = p.IdPersona
            });
        }

        public async Task<bool> RegistrarPersona(Persona persona)
        {
            var entity = new PersonaEntity
            {
                Nombre = persona.Nombre,
                Apellido1 = persona.Apellido1,
                Apellido2 = persona.Apellido2,
                Correo = persona.Correo
            };

            _context.Personas.Add(entity);
            var filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
    }
}
