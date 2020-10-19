using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Seguridad.Dtos
{
    public class RegistrarUsuarioRespuestaDto
    {

        [JsonProperty(PropertyName = "mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty(PropertyName = "suceso")]
        public bool Suceso { get; set; }

    }
}
