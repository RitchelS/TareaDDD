using Dominio.Entidades;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infraestuctura.Contexto;

namespace Infraestuctura.Repositorios
{
    public class PersonaRepositorio : IPersonaRepositorio
    {

        private readonly ContextoDB _context;

        public PersonaRepositorio(ContextoDB context)
        {
            _context = context;
        }

        public Task<bool> ActualizarDatosPersona(int idPersona, string nombre, string apellido1, string apellido2, string correo)
        {
            throw new NotImplementedException();
        }

        public Task<Persona> BuscarPersonaPorId(int idPersona)
        {
            throw new NotImplementedException();
        }

        public Task<Persona> EliminarPersona(int idPersona)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persona>> ObtenerPersonas()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrarPersona(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
