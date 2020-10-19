using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.Sedes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Sedes.Servicios.Abstracciones
{
    public interface ISedeServicio
    {
        Task<OperacionDto<OperacionSedeRespuestaDto>> RegistrarSede(RegistrarSedePeticionDto peticion);
        Task<OperacionDto<OperacionSedeRespuestaDto>> EditarSede(RegistrarSedePeticionDto peticion);
        Task<OperacionDto<ObtenerSedesDto>> ObtenerSedes();
        Task<OperacionDto<RegistrarSedePeticionDto>> DetalleSede(string id);
        Task<OperacionDto<OperacionSedeRespuestaDto>> EliminarSede(string id);

    }
}
