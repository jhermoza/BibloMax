using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Persona;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Usuario;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.General.Utilitarios;
using Hermoza.BibloMax.Servicios.Seguridad.Dtos;
using Hermoza.BibloMax.Servicios.Seguridad.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Seguridad.Servicios.Implementaciones
{
    public class UsuarioServicio : IUsuarioServicio
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly AppConfiguracionesDto _appConfiguraciones;

        public UsuarioServicio(
            IUsuarioRepositorio usuarioRepositorio,
            IPersonaRepositorio personaRepositorio,
            AppConfiguracionesDto appConfiguraciones)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _personaRepositorio = personaRepositorio;
            _appConfiguraciones = appConfiguraciones;
        }

        public async Task<OperacionDto<CambiarContraseniaRespuestaDto>> CambiarContrasenia(CambiarContraseniaPeticionDto peticion)
        {

            var validaModelo = ValidacionUtilitario.ValidarModelo<CambiarContraseniaRespuestaDto>(peticion);

            if (!validaModelo.Completado)
            {
                return validaModelo;
            }

            var entidad = await _usuarioRepositorio.BuscarPorId(peticion.IdUsuario);

            if (entidad == null)
            {
                return new OperacionDto<CambiarContraseniaRespuestaDto>(CodigosOperacionDto.NoExiste, "Usuario no existe");
            }

            if (!Md5Utilitario.Cifrar(peticion.Password, entidad.PasswordSalt).Equals(entidad.Password))
            {
                return new OperacionDto<CambiarContraseniaRespuestaDto>(CodigosOperacionDto.UsuarioIncorrecto, "Contraseña inválida");
            }

            var password = Md5Utilitario.Cifrar(peticion.NewPassword, entidad.PasswordSalt);
            entidad.Password = password;

            await _usuarioRepositorio.EditarUsuario(entidad);

            return new OperacionDto<CambiarContraseniaRespuestaDto>(new CambiarContraseniaRespuestaDto()
            {

                Mensaje = "Contraseña cambiada correctamente",
                Suceso = true

            });

        }

        public async Task<OperacionDto<RecuperarContraseniaRespuestaDto>> RecuperarContrasenia(RecuperarContraseniaPeticionDto peticion)
        {

            var validadModelo = ValidacionUtilitario.ValidarModelo<RecuperarContraseniaRespuestaDto>(peticion);

            if (!validadModelo.Completado)
            {
                return validadModelo;
            }

            var entidad = await _usuarioRepositorio.BuscarPorUserName(peticion.UserName);

            if (entidad == null)
            {
                return new OperacionDto<RecuperarContraseniaRespuestaDto>(CodigosOperacionDto.NoExiste, "Usuario no existe");
            }

            var persona = await _personaRepositorio.ObtenerPorIdUsuario(entidad.IdUsuario);

            var nombreCompleto = default(string);

            if (persona != null)
            {
                nombreCompleto = $@"{persona.Nombre}, {persona.APaterno} {persona.AMaterno}";
            }
            
            var password = RandomChars.RandomString(10);
            password = Regex.Replace(password, @"[^a-zA-Z0-9]", m => "9");

            entidad.Password = Md5Utilitario.Cifrar(password, entidad.PasswordSalt);

            var html = File.ReadAllText(_appConfiguraciones.RutaTemplateRecuperarContrasenia);

            html = html.Replace("%%Nombre%%", nombreCompleto);
            html = html.Replace("%%Contrasenia%%", password);

            var asunto = "Nueva Contraseña";
            var cuerpo = html;

            var destinatarios = new List<string>();
            destinatarios.Add(persona.Correo);

            CorreoUtiliario.EnviarCorreo(asunto, destinatarios, cuerpo);

            await _usuarioRepositorio.EditarUsuario(entidad);

            return new OperacionDto<RecuperarContraseniaRespuestaDto>(new RecuperarContraseniaRespuestaDto()
            {
                Mensaje = "Correo Enviado",
                Suceso = true
            });

        }

        public async Task<OperacionDto<RegistrarUsuarioRespuestaDto>> RegistrarUsuario(RegistrarUsuarioPeticionDto peticion)
        {

            var validaModelo = ValidacionUtilitario.ValidarModelo<RegistrarUsuarioPeticionDto>(peticion);

            if (!validaModelo.Completado)
            {
                return new OperacionDto<RegistrarUsuarioRespuestaDto>(CodigosOperacionDto.CamposRequeridos, validaModelo.Mensajes);
            }


            //var password = RandomChars.RandomString(10);
            var password = peticion.Password;
            var passwordSalt = RijndaelUtilitario.EncryptRijndaelToBase64(password);
                                    
            var username = "A" + DateTime.UtcNow.Year.ToString() + RandomChars.RandomFecha(5, DateTime.UtcNow.Millisecond.ToString());

            var entidad = await _usuarioRepositorio.BuscarPorUserName(username);

            while (entidad != null)
            {
                username = "A" + DateTime.UtcNow.Year.ToString() + RandomChars.RandomFecha(5, DateTime.UtcNow.Millisecond.ToString());

                if (!entidad.Username.Equals(username))
                {
                    break;
                }
            }

            var usuario = new Usuario()
            {
                Username = username,
                Password = Md5Utilitario.Cifrar(password, passwordSalt),
                PasswordSalt = passwordSalt
            };

            var valorUsuario = await _usuarioRepositorio.Registro(usuario);

            if (valorUsuario <= 0)
            {
                return new OperacionDto<RegistrarUsuarioRespuestaDto>(new RegistrarUsuarioRespuestaDto()
                {
                    Mensaje = "Error al crear Usuario",
                    Suceso = false
                });
            }

            var persona = new Persona()
            {
                Nombre = peticion.Nombre,
                APaterno = peticion.APaterno,
                AMaterno = peticion.AMaterno,
                Telefono = peticion.Telefono,
                Correo = peticion.Correo,
                FechaNacimiento = peticion.FechaNacimiento,
                IdUsuario = usuario.IdUsuario,
                Direccion = peticion.Direccion
            };
            
            var valorPersona = await _personaRepositorio.Registro(persona);

            if (valorPersona <= 0)
            {
                return new OperacionDto<RegistrarUsuarioRespuestaDto>(new RegistrarUsuarioRespuestaDto()
                {
                    Mensaje = "Error al crear Usuario",
                    Suceso = false
                });
            }

            return new OperacionDto<RegistrarUsuarioRespuestaDto>(new RegistrarUsuarioRespuestaDto()
            {
                Mensaje = "Usuario creado correctamente",
                Suceso = true
            });
        }
    }
}
