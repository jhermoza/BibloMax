using AutoMapper;
using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Servicios.Seguridad.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Seguridad.Profiles
{
    public class RegistrarUsuarioPeticionProfile : Profile
    {

        public RegistrarUsuarioPeticionProfile()
        {
            CreateMap<RegistrarUsuarioPeticionDto, Usuario>();
            CreateMap<RegistrarUsuarioPeticionDto, Persona>();
        }

    }
}
