using Hermoza.BibloMax.Datos.Infraestructura.Conexiones;
using Hermoza.BibloMax.Datos.Infraestructura.Contextos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Usuario;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Implementaciones.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SOContexto _context;

        public UsuarioRepositorio(SOContexto context)
        {
            _context = context;
        }

        public async Task<int> Registro(Modelos.Usuario entidad)
        {
            _context.Usuario.Add(entidad);
            var salida = await _context.SaveChangesAsync();

            return salida;

        }

        public async Task<Modelos.Usuario> BuscarPorUserName(string username)
           => await _context.Usuario.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();

        public async Task<int> EditarUsuario(Modelos.Usuario entidad)
        {
            var usr = await _context.Usuario.FindAsync(entidad.IdUsuario);

            if (usr == null)
            {
                return 0;
            }

            usr.Username = entidad.Username != null ? entidad.Username : usr.Username;
            usr.Password = entidad.Password != null ? entidad.Password : usr.Password; 
            usr.PasswordSalt = entidad.PasswordSalt != null ? entidad.PasswordSalt : usr.PasswordSalt; 
            usr.Actualizado = DateTime.UtcNow;

            var salida = await _context.SaveChangesAsync();

            return salida;

        }

        public async Task<Modelos.Usuario> BuscarPorId(int id)
            => await _context.Usuario.FindAsync(id);

    }
}
