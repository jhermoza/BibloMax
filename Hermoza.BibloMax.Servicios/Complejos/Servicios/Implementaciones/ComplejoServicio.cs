using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones;
using Hermoza.BibloMax.Servicios.Complejos.Dtos;
using Hermoza.BibloMax.Servicios.Complejos.Servicios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.General.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Complejos.Servicios.Implementaciones
{
    public class ComplejoServicio : IComplejoServicio
    {

        private readonly IComplejoRepositorio _complejoRepositorio;

        public ComplejoServicio(IComplejoRepositorio complejoRepositorio)
        {
            _complejoRepositorio = complejoRepositorio;
        }

        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> RegistrarComplejo(RegistrarComplejoPeticionDto peticion)
        {
            var validaModelo = ValidacionUtilitario.ValidarModelo<RegistrarComplejoPeticionDto>(peticion);

            if (!validaModelo.Completado)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(CodigosOperacionDto.CamposRequeridos, validaModelo.Mensajes);
            }

            var entidad = await _complejoRepositorio.BuscarPorId(peticion.IdComplejo);

            if (entidad != null)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
                {
                    Mensaje = "Error al registrar Complejo",
                    Suceso = false
                });
            }

            peticion.IdSede = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(peticion.SedeCifrado);

            var complejo = new Complejo()
            {
                Localidad = peticion.Localidad,
                Jefe = peticion.Jefe,
                AreaTotal = peticion.AreaTotal,
                IdSede = peticion.IdSede
            };

            var valorComplejo = await _complejoRepositorio.Registro(complejo);

            if (valorComplejo <= 0)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
                {
                    Mensaje = "Error al registrar Complejo",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
            {
                Mensaje = "Complejo registrado correctamente",
                Suceso = true
            });
        }

        public async Task<OperacionDto<ObtenerComplejosDto>> ObtenerComplejos()
        {

            List<RegistrarComplejoPeticionDto> listado = new List<RegistrarComplejoPeticionDto>();

            var complejos = await _complejoRepositorio.ObtenerComplejos();

            if (complejos.Count <= 0)
            {
                return new OperacionDto<ObtenerComplejosDto>(new ObtenerComplejosDto()
                {
                    Complejos = listado
                });
            }

            foreach (var item in complejos)
            {

                var cifrado = RijndaelUtilitario.EncryptRijndaelToBase64(item.IdComplejo.ToString());
                var sedecifrado = RijndaelUtilitario.EncryptRijndaelToBase64(item.IdSede.ToString());

                var dto = new RegistrarComplejoPeticionDto()
                {
                    IdComplejo = item.IdComplejo,
                    Id = cifrado,
                    Localidad = item.Localidad,
                    Jefe = item.Jefe,
                    AreaTotal = item.AreaTotal,
                    IdSede = item.IdSede,
                    SedeCifrado = sedecifrado
                };

                listado.Add(dto);

            }

            return new OperacionDto<ObtenerComplejosDto>(new ObtenerComplejosDto()
            {
                Draw = 1,
                RecordsTotal = complejos.Count,
                RecordsFiltered = complejos.Count,
                Complejos = listado,
            });
        }

        public async Task<OperacionDto<RegistrarComplejoPeticionDto>> DetalleComplejo(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return new OperacionDto<RegistrarComplejoPeticionDto>(CodigosOperacionDto.Invalido, "Error al obtener datos del Complejo.");
            }

            var idComplejo = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(id);

            var entidad = await _complejoRepositorio.BuscarPorId(idComplejo);

            if (entidad == null)
            {
                return new OperacionDto<RegistrarComplejoPeticionDto>(CodigosOperacionDto.NoExiste, "No se encontraron datos del Complejo.");
            }

            var sedeCifrado = RijndaelUtilitario.EncryptRijndaelToBase64(entidad.IdSede.ToString());

            var dto = new RegistrarComplejoPeticionDto()
            {
                Id = id,
                IdComplejo = entidad.IdComplejo,
                Localidad = entidad.Localidad,
                Jefe = entidad.Jefe,
                AreaTotal = entidad.AreaTotal,
                IdSede = entidad.IdSede,
                SedeCifrado = sedeCifrado
            };

            return new OperacionDto<RegistrarComplejoPeticionDto>(dto);

        }

        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> EliminarComplejo(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(CodigosOperacionDto.Invalido, "Error al obtener datos del Complejo.");
            }

            var idComplejo = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(id);

            var entidad = await _complejoRepositorio.BuscarPorId(idComplejo);

            if (entidad == null)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(CodigosOperacionDto.NoExiste, "No se encontraron datos del Complejo.");
            }

            entidad.EstaBorrado = true;
            entidad.Borrado = DateTime.UtcNow;

            var valorEdicion = await _complejoRepositorio.EditarComplejo(entidad);

            if (valorEdicion <= 0)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
                {
                    Mensaje = "Error al eliminar Complejo",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
            {
                Mensaje = "Se eliminó el complejo safisfactoriamente",
                Suceso = true
            });

        }

        public async Task<OperacionDto<OperacionComplejoRespuestaDto>> EditarComplejo(RegistrarComplejoPeticionDto peticion)
        {
            var validaModelo = ValidacionUtilitario.ValidarModelo<RegistrarComplejoPeticionDto>(peticion);

            if (!validaModelo.Completado)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(CodigosOperacionDto.CamposRequeridos, validaModelo.Mensajes);
            }

            var idComplejo = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(peticion.Id);

            var entidad = await _complejoRepositorio.BuscarPorId(idComplejo);

            if (entidad == null)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
                {
                    Mensaje = "Error al obtener datos de Complejo",
                    Suceso = false
                });
            }

            peticion.IdSede = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(peticion.SedeCifrado);

            entidad.Localidad = peticion.Localidad;
            entidad.Jefe = peticion.Jefe;
            entidad.AreaTotal = peticion.AreaTotal;
            entidad.IdSede = peticion.IdSede;

            var valorComplejo = await _complejoRepositorio.EditarComplejo(entidad);

            if (valorComplejo <= 0)
            {
                return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
                {
                    Mensaje = "Error al actualizar Complejo",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionComplejoRespuestaDto>(new OperacionComplejoRespuestaDto()
            {
                Mensaje = "Complejo actualizado correctamente",
                Suceso = true
            });
        }
    }
}
