using Hermoza.BibloMax.Servicios.General.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Integracion.Infraestructura
{
    public class Valores
    {
        
        private static readonly AppConfiguracionesDto _appConfiguraciones;
        
        public static string PasswordSalt
        {
            get
            {
                return _appConfiguraciones.PassworSalt;
            }
        }
    }
}
