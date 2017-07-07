using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IGrupoAcessoPermissaoService: IServiceBase<GrupoAcessoPermissao>
    {
        IEnumerable<GrupoAcessoPermissao> BuscaGrupoPorPermissao(int id);

        IEnumerable<GrupoAcessoPermissao> BuscaPermissaoPorGrupo(int id);

        IEnumerable<GrupoAcessoPermissao> ListaGrupoPorPermissao(int id);

        IEnumerable<GrupoAcessoPermissao> ListaPermissaoPorGrupo(int id);

    }
}