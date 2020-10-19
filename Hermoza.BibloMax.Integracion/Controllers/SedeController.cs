using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hermoza.BibloMax.Integracion.Infraestructura.Seguridad;
using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.Sedes.Dtos;
using Hermoza.BibloMax.Servicios.Sedes.Servicios.Abstracciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hermoza.BibloMax.Integracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControladorBase
    {

        private readonly ISedeServicio _sedeServicio;
        private readonly IAuthServicio _authServicio;

        public SedeController(ISedeServicio sedeServicio,
                              IAuthServicio authServicio)
        {
            _sedeServicio = sedeServicio;
            _authServicio = authServicio;
        }



        [HttpPost]
        [Route("RegistrarSede")]
        public async Task<OperacionDto<OperacionSedeRespuestaDto>> RegistrarSede(RegistrarSedePeticionDto peticion)
        {

            if (!string.IsNullOrEmpty(peticion.Id))
            {
                var editar = await _sedeServicio.EditarSede(peticion);
                return editar;
            }

            var registrar = await _sedeServicio.RegistrarSede(peticion);

            return registrar;

        }

        [HttpPost]
        [Route("ObtenerSedes")]
        public async Task<ObtenerSedesDto> ObtenerSedes()
        {

            var operacion = await _sedeServicio.ObtenerSedes();

            return operacion.Resultado;

        }

        [HttpPost]
        [Route("DetalleSede")]
        public async Task<OperacionDto<RegistrarSedePeticionDto>> DetalleSede(PeticionIdDto peticion)
        {

            var id = String.IsNullOrEmpty(peticion.Id) ? "" : peticion.Id;

            var operacion = await _sedeServicio.DetalleSede(id);

            return operacion;

        }

        [HttpPost]
        [Route("EliminarSede")]
        public async Task<OperacionDto<OperacionSedeRespuestaDto>> EliminarSede(PeticionIdDto peticion)
        {

            var id = String.IsNullOrEmpty(peticion.Id) ? "" : peticion.Id;

            var operacion = await _sedeServicio.EliminarSede(id);

            return operacion;

        }

        [HttpPost]
        [Route("EditarSede")]
        public async Task<OperacionDto<OperacionSedeRespuestaDto>> EditarSede(RegistrarSedePeticionDto peticion)
        {

            var operacion = await _sedeServicio.EditarSede(peticion);

            return operacion;

        }

    }
}
