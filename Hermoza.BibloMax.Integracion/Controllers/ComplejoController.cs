using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.Complejos.Dtos;
using Hermoza.BibloMax.Servicios.Complejos.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hermoza.BibloMax.Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplejoController : ControllerBase
    {

        private readonly IComplejoServicio _complejoServicio;
        private readonly IAuthServicio _authServicio;

        public ComplejoController(IComplejoServicio complejoServicio,
                              IAuthServicio authServicio)
        {
            _complejoServicio = complejoServicio;
            _authServicio = authServicio;
        }



        [HttpPost]
        [Route("RegistrarComplejo")]
        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> RegistrarComplejo(RegistrarComplejoPeticionDto peticion)
        {

            if (!string.IsNullOrEmpty(peticion.Id))
            {
                var editar = await _complejoServicio.EditarComplejo(peticion);
                return editar;
            }

            var registrar = await _complejoServicio.RegistrarComplejo(peticion);

            return registrar;

        }

        [HttpPost]
        [Route("ObtenerComplejos")]
        public async Task<ObtenerComplejosDto> ObtenerComplejos()
        {

            var operacion = await _complejoServicio.ObtenerComplejos();

            return operacion.Resultado;

        }

        [HttpPost]
        [Route("DetalleComplejo")]
        public async Task<OperacionDto<RegistrarComplejoPeticionDto>> DetalleComplejo(PeticionIdDto peticion)
        {

            var id = String.IsNullOrEmpty(peticion.Id) ? "" : peticion.Id;

            var operacion = await _complejoServicio.DetalleComplejo(id);

            return operacion;

        }

        [HttpPost]
        [Route("EliminarComplejo")]
        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> EliminarComplejo(PeticionIdDto peticion)
        {

            var id = String.IsNullOrEmpty(peticion.Id) ? "" : peticion.Id;

            var operacion = await _complejoServicio.EliminarComplejo(id);

            return operacion;

        }

        [HttpPost]
        [Route("EditarComplejo")]
        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> EditarComplejo(RegistrarComplejoPeticionDto peticion)
        {

            var operacion = await _complejoServicio.EditarComplejo(peticion);

            return operacion;

        }

    }
}
