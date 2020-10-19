using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.General.Dtos
{
    public class CorreoParametrosDto
    {

        public string Asunto { get; set; }
        public string From { get; set; }
        public bool EnableSSL { get; set; }
        public string UsuarioSmtp { get; set; }
        public string PasswordSmtp { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public List<string> To { get; set; }
        public string Cuerpo { get; set; }

    }
}
