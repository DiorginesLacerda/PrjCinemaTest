using System.Collections.Generic;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IUsuarioService : IUsuarioRepository
    {
        IEnumerable<Usuario> UsuariosAtivos();
    }
}