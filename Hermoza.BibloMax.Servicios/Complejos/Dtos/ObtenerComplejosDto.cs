using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Complejos.Dtos
{
    public class ObtenerComplejosDto
    {

        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<RegistrarComplejoPeticionDto> Complejos { get; set; }

        public ObtenerComplejosDto()
        {
            Complejos = new List<RegistrarComplejoPeticionDto>();
        }

    }
}
