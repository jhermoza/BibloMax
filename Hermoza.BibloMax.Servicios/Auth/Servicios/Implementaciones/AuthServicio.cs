using Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Usuario;
using Hermoza.BibloMax.Servicios.Auth.Dtos;
using Hermoza.BibloMax.Servicios.Auth.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.General.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Auth.Servicios.Implementaciones
{
    public class AuthServicio : IAuthServicio
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AuthServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<OperacionDto<LoginRespuestaDto>> Login(LoginPeticionDto peticion)
        {
            var operacionValidacion = ValidacionUtilitario.ValidarModelo<LoginRespuestaDto>(peticion);

            if (!operacionValidacion.Completado)
            {
                return operacionValidacion;
            }

            var usuario = await _usuarioRepositorio.BuscarPorUserName(peticion.UserName);

            if (usuario == null)
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.AccesoInvalido, "Usuario o Contraseña inválida");
            }

            if (!Md5Utilitario.Cifrar(peticion.Password, usuario.PasswordSalt).Equals(usuario.Password))
            {
                return new OperacionDto<LoginRespuestaDto>(CodigosOperacionDto.AccesoInvalido, "Usuario o Contraseña inválida");
            }

            var token = $"{peticion.UserName}___{DateTime.UtcNow.ToBinary()}___HERMOZA_BIBLOMAX";

            var dto = new LoginRespuestaDto()
            {

                Suceso = true,
                Descripcion = "Login correcto",
                Token = RijndaelUtilitario.EncryptRijndaelToBase64(token)

            };

            return new OperacionDto<LoginRespuestaDto>(dto);

        }

        public async Task<OperacionDto<long>> ObtenerIdUsuarioDeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return new OperacionDto<long>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var descifrado = RijndaelUtilitario.DecryptRijndaelFromBase64<string>(token);

            if (string.IsNullOrWhiteSpace(descifrado))
            {
                return new OperacionDto<long>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var datos = descifrado.Split(new string[] { "___" }, StringSplitOptions.None);

            if (datos.Length == 0)
            {
                return new OperacionDto<long>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var username = datos[0].ToString();

            var usuario = await _usuarioRepositorio.BuscarPorUserName(username);

            if (usuario == null)
            {
                return new OperacionDto<long>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            return new OperacionDto<long>(usuario.IdUsuario); 
        }

        public async Task<OperacionDto<string>> ValidarToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return new OperacionDto<string>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var descifrado = RijndaelUtilitario.DecryptRijndaelFromBase64<string>(token);

            if (string.IsNullOrWhiteSpace(descifrado))
            {
                return new OperacionDto<string>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var datos = descifrado.Split(new string[] { "___" }, StringSplitOptions.None);

            if (datos.Length == 0)
            {
                return new OperacionDto<string>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            var username = datos[0].ToString();

            var usuario = await _usuarioRepositorio.BuscarPorUserName(username);

            if (usuario == null)
            {
                return new OperacionDto<string>(CodigosOperacionDto.AccesoInvalido, "Token inválido");
            }

            return new OperacionDto<string>("Token válido");
        }
    }
}
