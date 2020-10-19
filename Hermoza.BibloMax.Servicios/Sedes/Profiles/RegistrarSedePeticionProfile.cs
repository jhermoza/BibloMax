using AutoMapper;
using Hermoza.BibloMax.Datos.Modelos;
using Hermoza.BibloMax.Servicios.Sedes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermoza.BibloMax.Servicios.Sedes.Profiles
{
    public class RegistrarSedePeticionProfile : Profile
    {

        public RegistrarSedePeticionProfile()
        {
            CreateMap<RegistrarSedePeticionDto, Sede>();
        }

    }
}
