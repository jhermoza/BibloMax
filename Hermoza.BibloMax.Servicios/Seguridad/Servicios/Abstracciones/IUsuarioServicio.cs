using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.Seguridad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Seguridad.Servicios.Abstracciones
{
    public interface IUsuarioServicio
    {

        Task<OperacionDto<RegistrarUsuarioRespuestaDto>> RegistrarUsuario(RegistrarUsuarioPeticionDto peticion);

        Task<OperacionDto<CambiarContraseniaRespuestaDto>> CambiarContrasenia(CambiarContraseniaPeticionDto peticion);

        Task<OperacionDto<RecuperarContraseniaRespuestaDto>> RecuperarContrasenia(RecuperarContraseniaPeticionDto peticion); 

    }
}
