using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IPersonaServicio
    {
        public Task<bool> ActualizarDatosPersona(int idPersona, string nombre, string apellido1, string apellido2, string correo);
        public Task<Persona> BuscarPersonaPorId(int idPersona);
        public Task<IEnumerable<Persona>> ObtenerPersonas();
        public Task<bool> RegistrarPersona(Persona persona);
        public Task<bool> EliminarPersona(int idPersona);
    }
}
