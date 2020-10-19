using Hermoza.BibloMax.Datos.Infraestructura.Contextos;
using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Implementaciones
{
    public class ComplejoRepositorio : IComplejoRepositorio
    {

        private readonly SOContexto _context;

        public ComplejoRepositorio(SOContexto context)
        {
            _context = context;
        }

        public async Task<Complejo> BuscarPorId(int id)
            => await _context.Complejo.FindAsync(id);

        public async Task<int> EditarComplejo(Complejo entidad)
        {
            var complejo = await _context.Complejo.FindAsync(entidad.IdComplejo);

            if (complejo == null)
            {
                return 0;
            }

            complejo.Localidad = entidad.Localidad != null ? entidad.Localidad : complejo.Localidad;
            complejo.Jefe = entidad.Jefe != null ? entidad.Jefe : complejo.Jefe;
            complejo.AreaTotal = entidad.AreaTotal >= 0 ? entidad.AreaTotal : complejo.AreaTotal;
            complejo.IdSede = entidad.IdSede >= 0 ? entidad.IdSede : complejo.IdSede;
            complejo.Actualizado = DateTime.UtcNow;

            var salida = await _context.SaveChangesAsync();

            return salida;
        }

        public async Task<List<Complejo>> ObtenerComplejos()
            => await _context.Complejo.Where(x => !x.EstaBorrado).ToListAsync();

        public async Task<int> Registro(Complejo entidad)
        {
            _context.Complejo.Add(entidad);
            var salida = await _context.SaveChangesAsync();

            return salida;
        }

    }
}
