using Hermoza.BibloMax.Servicios.Auth.Dtos;
using Hermoza.BibloMax.Servicios.General.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones
{
    public interface IAuthServicio
    {

        Task<OperacionDto<string>> ValidarToken(string token);

        Task<OperacionDto<LoginRespuestaDto>> Login(LoginPeticionDto peticion);

        Task<OperacionDto<long>> ObtenerIdUsuarioDeToken(string token);

    }
}
