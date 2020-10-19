using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Seguridad.Dtos
{
    public class CambiarContraseniaPeticionDto
    {

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "newPassword")]
        public string NewPassword { get; set; }

        [JsonProperty(PropertyName = "correo")]
        public string Correo { get; set; }

        [JsonIgnore]
        public int IdUsuario { get; set; }

    }
}
