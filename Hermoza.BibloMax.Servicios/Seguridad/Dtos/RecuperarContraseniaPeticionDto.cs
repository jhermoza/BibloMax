using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Seguridad.Dtos
{
    public class RecuperarContraseniaPeticionDto
    {
        [Required(ErrorMessage = "Usuario es requerida")]
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }
        
    }
}
