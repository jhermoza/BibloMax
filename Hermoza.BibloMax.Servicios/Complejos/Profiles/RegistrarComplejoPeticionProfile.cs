using AutoMapper;
using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Servicios.Complejos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Complejos.Profiles
{
    public class RegistrarComplejoPeticionProfile : Profile
    {

        public RegistrarComplejoPeticionProfile()
        {
            CreateMap<RegistrarComplejoPeticionDto, Complejo>();
        }

    }
}
