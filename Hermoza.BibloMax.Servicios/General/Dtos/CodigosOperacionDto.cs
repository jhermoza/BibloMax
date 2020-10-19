using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.General.Dtos
{
    public enum CodigosOperacionDto
    {
        Suceso,
        ResultadoVacio,
        UsuarioIncorrecto,
        UsuarioInhabilitado,
        OperacionNoDisponible,
        AccesoInvalido,
        NoExiste,
        ErrorServidor,
        Invalido,
        DniInexistente = 410,
        NoSePudoRealizarPago = 1034,
        CamposRequeridos = 400
    };
}
