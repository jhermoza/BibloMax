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
    public class SedeRepositorio : ISedeRepositorio
    {

        private readonly SOContexto _context;

        public SedeRepositorio(SOContexto context)
        {
            _context = context;
        }

        public async Task<Sede> BuscarPorId(int id)
            => await _context.Sede.FindAsync(id);

        public async Task<int> EditarSede(Sede entidad)
        {
            var sede = await _context.Sede.FindAsync(entidad.IdSede);

            if (sede == null)
            {
                return 0;
            }

            sede.Nombre = entidad.Nombre != null ? entidad.Nombre : sede.Nombre;
            sede.Ubicacion = entidad.Ubicacion != null ? entidad.Ubicacion : sede.Ubicacion;
            sede.NroComplejos = entidad.NroComplejos >= 0 ? entidad.NroComplejos : sede.NroComplejos;
            sede.Presupuesto = entidad.Presupuesto >= 0 ? entidad.Presupuesto : sede.Presupuesto;
            sede.Actualizado = DateTime.UtcNow;

            var salida = await _context.SaveChangesAsync();

            return salida;
        }

        public async Task<List<Sede>> ObtenerSedes()
            => await _context.Sede.Where(x => !x.EstaBorrado).ToListAsync();

        public async Task<int> Registro(Sede entidad)
        {
            _context.Sede.Add(entidad);
            var salida = await _context.SaveChangesAsync();

            return salida;
        }
    }
}
