using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hermoza.BibloMax.Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorBase : ControllerBase
    {

        public ActionResult<T> DevolverResultadoOMostrarErrores<T>(OperacionDto<T> operacion)
        {

            if (operacion.Completado)
            {
                return operacion.Resultado;
            }

            return BadRequest(new
            {
                mensajes = operacion.Mensajes
            });
        }

        protected string ObtenerTokenAcceso()
        {

            var token = default(string);

            if (Request.Headers.ContainsKey("token-acceso"))
            {
                token = Request.Headers["token-acceso"];
            }

            return token;
        }
                
    }
}