using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos
{
    public class Persona
    {

        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Actualizado { get; set; }

        public DateTime? Borrado { get; set; }

        public bool EstaBorrado { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Persona()
        {
            Creado = DateTime.UtcNow;
            Actualizado = DateTime.UtcNow;
            EstaBorrado = false;
        }

    }
}
