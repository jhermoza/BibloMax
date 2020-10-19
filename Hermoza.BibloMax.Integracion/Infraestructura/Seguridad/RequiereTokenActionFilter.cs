using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Integracion.Infraestructura.Seguridad
{
    public class RequiereTokenActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var token = default(string);
            var headers = context.HttpContext.Request.Headers;

            if (headers.ContainsKey("token-acceso"))
            {
                token = headers["token-acceso"];
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new UnauthorizedResult();
            }

            var authService = context.HttpContext.RequestServices.GetService(typeof(IAuthServicio)) as IAuthServicio;

            var operacion = await authService.ValidarToken(token);

            bool isAuthorized = operacion.Completado;

            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                await next();
            }
        }
    }
}
