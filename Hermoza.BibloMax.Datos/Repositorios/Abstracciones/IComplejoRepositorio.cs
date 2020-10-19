using Hermoza.BibloMax.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Abstracciones
{
    public interface IComplejoRepositorio
    {

        Task<int> Registro(Complejo entidad);

        Task<List<Complejo>> ObtenerComplejos();

        Task<int> EditarComplejo(Complejo entidad);

        Task<Complejo> BuscarPorId(int id);

    }
}
