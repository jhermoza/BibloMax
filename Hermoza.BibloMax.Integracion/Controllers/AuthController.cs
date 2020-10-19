using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hermoza.BibloMax.Integracion.Infraestructura.Seguridad;
using Hermoza.BibloMax.Servicios.Auth.Dtos;
using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.Seguridad.Dtos;
using Hermoza.BibloMax.Servicios.Seguridad.Servicios.Abstracciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hermoza.BibloMax.Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControladorBase
    {

        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IAuthServicio _authServicio; 

        public AuthController(IUsuarioServicio usuarioServicio,
                              IAuthServicio authServicio)
        {
            _usuarioServicio = usuarioServicio;
            _authServicio = authServicio;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<OperacionDto<LoginRespuestaDto>> Login([FromBody] LoginPeticionDto peticion)
        {
            var operacion = await _authServicio.Login(peticion);
            return operacion;
        }


        [HttpPost]
        [Route("RegistroUsuario")]
        public async Task<RegistrarUsuarioRespuestaDto> RegistrarUsuario(RegistrarUsuarioPeticionDto peticion)
        {

            var operacion = await _usuarioServicio.RegistrarUsuario(peticion);

            return operacion.Resultado;

        }

        [HttpPost]
        [RequiereToken]
        [Route("CambiarPass")]
        public async Task<CambiarContraseniaRespuestaDto> CambiarPass(CambiarContraseniaPeticionDto peticion)
        {
            var operacionUsuario = await _authServicio.ObtenerIdUsuarioDeToken(ObtenerTokenAcceso());

            var idUsuario = (int)operacionUsuario.Resultado;

            peticion.IdUsuario = idUsuario;

            var operacion = await _usuarioServicio.CambiarContrasenia(peticion);

            return operacion.Resultado;

        }

        [HttpPost]
        [Route("RecuperarPass")]
        public async Task<RecuperarContraseniaRespuestaDto> RecuperarPass(RecuperarContraseniaPeticionDto peticion)
        {
            
            var operacion = await _usuarioServicio.RecuperarContrasenia(peticion);

            return operacion.Resultado;

        }

    }
}