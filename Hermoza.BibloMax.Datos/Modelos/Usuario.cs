using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Actualizado { get; set; }

        public DateTime? Borrado { get; set; }

        public bool EstaBorrado { get; set; }

        public virtual Persona Persona { get; set; }

        public Usuario()
        {
            Creado = DateTime.UtcNow;
            Actualizado = DateTime.UtcNow;
            EstaBorrado = false;
        }

    }
}
