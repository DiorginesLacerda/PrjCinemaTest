using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class GrupoAcessoPermissaoService : ServiceBase<GrupoAcessoPermissao>, IGrupoAcessoPermissaoService
    {
        private readonly IGrupoAcessoPermissaoRepository _grupoAcessoPermissaoRepository;
        public GrupoAcessoPermissaoService(IGrupoAcessoPermissaoRepository grupoAcessoPermissaoRepository)
            :base(grupoAcessoPermissaoRepository)
        {
            _grupoAcessoPermissaoRepository = grupoAcessoPermissaoRepository;
        }

        public IEnumerable<GrupoAcessoPermissao> BuscaGrupoPorPermissao(int id)
        {
            return _grupoAcessoPermissaoRepository.BuscaGrupoPorPermissao(id);
        }

        public IEnumerable<GrupoAcessoPermissao> BuscaPermissaoPorGrupo(int id)
        {
            return _grupoAcessoPermissaoRepository.BuscaPermissaoPorGrupo(id);
        }


        public IEnumerable<GrupoAcessoPermissao> ListaGrupoPorPermissao(int id)
        {
            return _grupoAcessoPermissaoRepository.ListaGrupoPorPermissao(id);
        }

        public IEnumerable<GrupoAcessoPermissao> ListaPermissaoPorGrupo(int id)
        {
            return _grupoAcessoPermissaoRepository.ListaPermissaoPorGrupo(id);
        }
    }
}