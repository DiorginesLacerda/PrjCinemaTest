using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IGrupoAcessoUsuarioService : IServiceBase<GrupoAcessoUsuario>
    {
        IEnumerable<GrupoAcessoUsuario> BuscaGrupoPorUsuario(int id);

        IEnumerable<GrupoAcessoUsuario> BuscaUsuarioPorGrupo(int id);

        IEnumerable<GrupoAcessoPermissao> ListaGrupoPorUsuario(int id);

        IEnumerable<GrupoAcessoPermissao> ListaUsuarioPorGrupo(int id);
    }
}