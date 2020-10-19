using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermoza.BibloMax.Datos.Repositorios.Abstracciones.Usuario
{
    public interface IUsuarioRepositorio
    {

        Task<int> Registro(Hermoza.BibloMax.Datos.Modelos.Usuario entidad);

        Task<Hermoza.BibloMax.Datos.Modelos.Usuario> BuscarPorUserName(string username);

        Task<int> EditarUsuario(Hermoza.BibloMax.Datos.Modelos.Usuario entidad);

        Task<Hermoza.BibloMax.Datos.Modelos.Usuario> BuscarPorId(int id);

    }
}
