using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Integracion.Infraestructura.Seguridad
{
    public class RequiereTokenAttribute : TypeFilterAttribute
    {

        public RequiereTokenAttribute() : base(typeof(RequiereTokenActionFilter))
        {
            Arguments = new object[] { };
        }

    }
}
