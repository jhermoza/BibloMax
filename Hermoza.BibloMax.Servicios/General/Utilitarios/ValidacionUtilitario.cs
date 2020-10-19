using Hermoza.BibloMax.Servicios.General.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hermoza.BibloMax.Servicios.General.Utilitarios
{
    public class ValidacionUtilitario
    {

        public static OperacionDto<T> ValidarModelo<T>(Object objeto)
        {
            var contexto = new ValidationContext(objeto, null, null);
            var errores = new List<string>();
            var resultados = new List<ValidationResult>();
            var esValido = Validator.TryValidateObject(objeto, contexto, resultados, true);

            if (!esValido)
            {
                return new OperacionDto<T>(CodigosOperacionDto.Invalido, resultados.Select(e => e.ErrorMessage).ToList());
            }

            return new OperacionDto<T>(Activator.CreateInstance<T>());
        }

    }
}
