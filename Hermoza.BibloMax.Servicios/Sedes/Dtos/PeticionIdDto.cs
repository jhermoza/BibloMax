using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Sedes.Dtos
{
    public class PeticionIdDto
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
