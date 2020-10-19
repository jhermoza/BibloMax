using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Datos.Modelos
{
    public class Sede
    {

        public int IdSede { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public int NroComplejos { get; set; }

        public decimal Presupuesto { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Actualizado { get; set; }

        public DateTime? Borrado { get; set; }

        public bool EstaBorrado { get; set; }

        public virtual ICollection<Complejo> Complejos { get; set; }

        public Sede()
        {
            Creado = DateTime.UtcNow;
            Actualizado = DateTime.UtcNow;
            EstaBorrado = false;
        }

    }
}
