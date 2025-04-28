using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Aplicacion.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaServicio(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public async Task<bool> ActualizarDatosPersona(int idPersona, string nombre, string apellido1, string apellido2, string correo)
        {
            return await this._personaRepositorio.ActualizarDatosPersona(idPersona, nombre, apellido1, apellido2, correo);
        }

        public async Task<Persona> BuscarPersonaPorId(int idPersona)
        {
            return await this._personaRepositorio.BuscarPersonaPorId(idPersona);
        }

        public async Task<Persona> EliminarPersona(int idPersona)
        {
            return await this._personaRepositorio.EliminarPersona(idPersona);
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonas()
        {
            return await this._personaRepositorio.ObtenerPersonas();
        }

        public async Task<bool> RegistrarPersona(Persona persona)
        {
            return await this._personaRepositorio.RegistrarPersona(persona);
        }
    }
}
