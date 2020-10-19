using Hermoza.BibloMax.Servicios.Complejos.Dtos;
using Hermoza.BibloMax.Servicios.General.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Complejos.Servicios.Abstracciones
{
    public interface IComplejoServicio
    {

        Task<OperacionDto<OperacionComplejoRespuestaDto>> RegistrarComplejo(RegistrarComplejoPeticionDto peticion);
        Task<OperacionDto<OperacionComplejoRespuestaDto>> EditarComplejo(RegistrarComplejoPeticionDto peticion);
        Task<OperacionDto<ObtenerComplejosDto>> ObtenerComplejos();
        Task<OperacionDto<RegistrarComplejoPeticionDto>> DetalleComplejo(string id);
        Task<OperacionDto<OperacionComplejoRespuestaDto>> EliminarComplejo(string id);

    }
}
