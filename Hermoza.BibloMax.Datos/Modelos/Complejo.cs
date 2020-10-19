using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos
{
    public class Complejo
    {

        public int IdComplejo { get; set; }

        public string Localidad { get; set; }

        public string Jefe { get; set; }

        public int AreaTotal { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Actualizado { get; set; }

        public DateTime? Borrado { get; set; }

        public bool EstaBorrado { get; set; }

        public int IdSede { get; set; }

        public virtual Sede Sede { get; set; }

        public Complejo()
        {
            Creado = DateTime.UtcNow;
            Actualizado = DateTime.UtcNow;
            EstaBorrado = false;
        }

    }
}
