using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Datos.Repositorios.Abstracciones;
using Hermoza.BibloMax.Servicios.General.Dtos;
using Hermoza.BibloMax.Servicios.General.Utilitarios;
using Hermoza.BibloMax.Servicios.Sedes.Dtos;
using Hermoza.BibloMax.Servicios.Sedes.Servicios.Abstracciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Servicios.Sedes.Servicios.Implementaciones
{
    public class SedeServicio : ISedeServicio
    {

        private readonly ISedeRepositorio _sedeRepositorio;

        public SedeServicio(ISedeRepositorio sedeRepositorio)
        {
            _sedeRepositorio = sedeRepositorio;
        }

        public async Task<OperacionDto<OperacionSedeRespuestaDto>> RegistrarSede(RegistrarSedePeticionDto peticion)
        {
            var validaModelo = ValidacionUtilitario.ValidarModelo<RegistrarSedePeticionDto>(peticion);

            if (!validaModelo.Completado)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(CodigosOperacionDto.CamposRequeridos, validaModelo.Mensajes);
            }

            var entidad = await _sedeRepositorio.BuscarPorId(peticion.IdSede);

            if (entidad != null)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
                {
                    Mensaje = "Error al registrar Sede",
                    Suceso = false
                });
            }

            var sede = new Sede()
            {
                Nombre = peticion.Nombre,
                Ubicacion = peticion.Ubicacion,
                NroComplejos = peticion.NroComplejos,
                Presupuesto = peticion.Presupuesto
            };

            var valorSede = await _sedeRepositorio.Registro(sede);

            if (valorSede <= 0)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
                {
                    Mensaje = "Error al registrar Sede",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
            {
                Mensaje = "Sede registrada correctamente",
                Suceso = true
            });
        }

        public async Task<OperacionDto<ObtenerSedesDto>> ObtenerSedes()
        {

            List<RegistrarSedePeticionDto> listado = new List<RegistrarSedePeticionDto>();

            var sedes = await _sedeRepositorio.ObtenerSedes();

            if (sedes.Count <= 0)
            {
                return new OperacionDto<ObtenerSedesDto>(new ObtenerSedesDto()
                {
                    Sedes = listado
                });
            }

            foreach (var item in sedes)
            {

                var cifrado = RijndaelUtilitario.EncryptRijndaelToBase64(item.IdSede.ToString());

                var dto = new RegistrarSedePeticionDto()
                {
                    IdSede = item.IdSede,
                    Id = cifrado,
                    Nombre = item.Nombre,
                    NroComplejos = item.NroComplejos,
                    Presupuesto = item.Presupuesto,
                    Ubicacion = item.Ubicacion
                };

                listado.Add(dto);

            }

            return new OperacionDto<ObtenerSedesDto>(new ObtenerSedesDto()
            {
                Draw = 1,
                RecordsTotal = sedes.Count,
                RecordsFiltered = sedes.Count,
                Sedes = listado,
            });
        }

        public async Task<OperacionDto<RegistrarSedePeticionDto>> DetalleSede(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return new OperacionDto<RegistrarSedePeticionDto>(CodigosOperacionDto.Invalido, "Error al obtener datos de la Sede.");
            }

            var idSede = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(id);

            var entidad = await _sedeRepositorio.BuscarPorId(idSede);

            if (entidad == null)
            {
                return new OperacionDto<RegistrarSedePeticionDto>(CodigosOperacionDto.NoExiste, "No se encontraron datos de la Sede.");
            }

            var dto = new RegistrarSedePeticionDto()
            {
                Id = id,
                IdSede = entidad.IdSede,
                Nombre = entidad.Nombre,
                NroComplejos = entidad.NroComplejos,
                Presupuesto = entidad.Presupuesto,
                Ubicacion = entidad.Ubicacion
            };

            return new OperacionDto<RegistrarSedePeticionDto>(dto);

        }

        public async Task<OperacionDto<OperacionSedeRespuestaDto>> EliminarSede(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(CodigosOperacionDto.Invalido, "Error al obtener datos de la Sede.");
            }

            var idSede = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(id);

            var entidad = await _sedeRepositorio.BuscarPorId(idSede);

            if (entidad == null)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(CodigosOperacionDto.NoExiste, "No se encontraron datos de la Sede.");
            }

            entidad.EstaBorrado = true;
            entidad.Borrado = DateTime.UtcNow;

            var valorEdicion = await _sedeRepositorio.EditarSede(entidad);

            if (valorEdicion <= 0)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
                {
                    Mensaje = "Error al eliminar Sede",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
            {
                Mensaje = "Se eliminó la sede safisfactoriamente",
                Suceso = true
            });

        }

        public async Task<OperacionDto<OperacionSedeRespuestaDto>> EditarSede(RegistrarSedePeticionDto peticion)
        {
            var validaModelo = ValidacionUtilitario.ValidarModelo<RegistrarSedePeticionDto>(peticion);

            if (!validaModelo.Completado)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(CodigosOperacionDto.CamposRequeridos, validaModelo.Mensajes);
            }

            var idSede = RijndaelUtilitario.DecryptRijndaelFromBase64<int>(peticion.Id);

            var entidad = await _sedeRepositorio.BuscarPorId(idSede);

            if (entidad == null)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
                {
                    Mensaje = "Error al obtener datos de Sede",
                    Suceso = false
                });
            }

            entidad.Nombre = peticion.Nombre;
            entidad.Ubicacion = peticion.Ubicacion;
            entidad.NroComplejos = peticion.NroComplejos;
            entidad.Presupuesto = peticion.Presupuesto;

            var valorSede = await _sedeRepositorio.EditarSede(entidad);

            if (valorSede <= 0)
            {
                return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
                {
                    Mensaje = "Error al actualizar Sede",
                    Suceso = false
                });
            }

            return new OperacionDto<OperacionSedeRespuestaDto>(new OperacionSedeRespuestaDto()
            {
                Mensaje = "Sede actualizada correctamente",
                Suceso = true
            });
        }
    }
}
