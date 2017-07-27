using System.Collections.Generic;
using PrjCinema.Domain.Entities;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        IEnumerable<Usuario> UsuariosAtivos();
    }
}