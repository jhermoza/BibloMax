using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Seguridad.Dtos
{
    public class RegistrarUsuarioPeticionDto
    {
        [JsonIgnore]
        public long IdPersona { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "apepat")]
        public string APaterno { get; set; }

        [JsonProperty(PropertyName = "apemat")]
        public string AMaterno { get; set; }

        [JsonProperty(PropertyName = "telefono")]
        public string Telefono { get; set; }

        [JsonProperty(PropertyName = "correo")]
        public string Correo { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }

        [JsonProperty(PropertyName = "fechanac")]
        public DateTime FechaNacimiento { get; set; }

        [JsonIgnore]
        public long IdUsuario { get; set; }

        [JsonProperty(PropertyName = "sexo")]
        public long IdSexo { get; set; }

    }
}
