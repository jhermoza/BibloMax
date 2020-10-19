using Hermoza.BibloMax.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Abstracciones
{
    public interface ISedeRepositorio
    {

        Task<int> Registro(Sede entidad);

        Task<List<Sede>> ObtenerSedes();

        Task<int> EditarSede(Sede entidad);

        Task<Sede> BuscarPorId(int id);

    }
}
