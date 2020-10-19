using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Complejos.Dtos
{
    public class RegistrarComplejoPeticionDto
    {

        [JsonIgnore]
        public int IdComplejo { get; set; }

        [JsonProperty(PropertyName = "idComplejo")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "localidad")]
        public string Localidad { get; set; }

        [JsonProperty(PropertyName = "jefe")]
        public string Jefe { get; set; }

        [JsonProperty(PropertyName = "areaTotal")]
        public int AreaTotal { get; set; }

        [JsonProperty(PropertyName = "idSede")]
        public int IdSede { get; set; }

        [JsonProperty(PropertyName = "sedeCifrado")]
        public string SedeCifrado { get; set; }

    }
}
