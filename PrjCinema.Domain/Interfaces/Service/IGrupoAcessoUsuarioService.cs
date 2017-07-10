using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IGrupoAcessoUsuarioService : IServiceBase<GrupoAcessoUsuario>
    {
        IEnumerable<GrupoAcessoUsuario> BuscaGrupoPorUsuario(int id);

        IEnumerable<GrupoAcessoUsuario> BuscaUsuarioPorGrupo(int id);

        IEnumerable<GrupoAcessoUsuario> ListaGrupoPorUsuario(int id);

        IEnumerable<GrupoAcessoUsuario> ListaUsuarioPorGrupo(int id);

        ICollection<GrupoAcessoUsuario> ListaGrupoAcessoPorUsuarioCollection(int id);
    }
}