using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Sedes.Dtos
{
    public class ObtenerSedesDto
    {

        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<RegistrarSedePeticionDto> Sedes { get; set; }

        public ObtenerSedesDto()
        {
            Sedes = new List<RegistrarSedePeticionDto>();
        }

    }
}
