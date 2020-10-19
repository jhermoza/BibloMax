using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Persona
{
    public interface IPersonaRepositorio
    {

        Task<int> Registro(Hermoza.BibloMax.Datos.Modelos.Persona entidad);
        Task<Modelos.Persona> ObtenerPorIdUsuario(int id);

    }
}
