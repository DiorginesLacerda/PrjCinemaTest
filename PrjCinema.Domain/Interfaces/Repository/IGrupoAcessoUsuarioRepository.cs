using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IGrupoAcessoUsuarioRepository : IRepositoryBase<GrupoAcessoUsuario>
    {
        IEnumerable<GrupoAcessoUsuario> BuscaGrupoPorUsuario(int id);
        
        IEnumerable<GrupoAcessoUsuario> BuscaUsuarioPorGrupo(int id);

        IEnumerable<GrupoAcessoUsuario> ListaGrupoPorUsuario(int id);

        IEnumerable<GrupoAcessoUsuario> ListaUsuarioPorGrupo(int id);

        ICollection<GrupoAcessoUsuario> ListaGrupoAcessoPorUsuarioCollection(int id);
    }
}