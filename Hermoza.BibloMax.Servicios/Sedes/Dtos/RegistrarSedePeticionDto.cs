using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Sedes.Dtos
{
    public class RegistrarSedePeticionDto
    {
        
        [JsonIgnore]
        public int IdSede { get; set; }

        [JsonProperty(PropertyName = "idSede")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "ubicacion")]
        public string Ubicacion { get; set; }

        [JsonProperty(PropertyName = "nroComplejos")]
        public int NroComplejos { get; set; }

        [JsonProperty(PropertyName = "presupuesto")]
        public decimal Presupuesto { get; set; }

    }
}
