using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Auth.Dtos
{
    public class LoginRespuestaDto
    {

        [JsonProperty(PropertyName = "suceso")]
        public bool Suceso { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

    }
}
