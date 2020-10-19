using Hermoza.BibloMax.Datos.Infraestructura.Conexiones;
using Hermoza.BibloMax.Datos.Infraestructura.Contextos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Persona;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Implementaciones.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {

        private readonly SOContexto _context;

        public PersonaRepositorio(SOContexto context)
        {
            _context = context;
        }

        public async Task<Modelos.Persona> ObtenerPorIdUsuario(int id)
            => await _context.Persona.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();

        
        public async Task<int> Registro(Modelos.Persona entidad)
        {
             _context.Persona.Add(entidad);
            var salida = await _context.SaveChangesAsync();

            return salida;

        }
    }
}
