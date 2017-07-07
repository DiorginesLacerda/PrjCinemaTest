using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class GrupoAcessoUsuarioService : ServiceBase<GrupoAcessoUsuario>, IGrupoAcessoUsuarioService
    {
        private readonly IGrupoAcessoUsuarioRepository _grupoAcessoUsuarioRepository;

        public GrupoAcessoUsuarioService(IGrupoAcessoUsuarioRepository grupoAcessoUsuarioRepository)
            : base(grupoAcessoUsuarioRepository)
        {
            _grupoAcessoUsuarioRepository = grupoAcessoUsuarioRepository;
        }


        public IEnumerable<GrupoAcessoUsuario> BuscaGrupoPorUsuario(int id)
        {
            return _grupoAcessoUsuarioRepository.BuscaGrupoPorUsuario(id);
        }

        public IEnumerable<GrupoAcessoUsuario> BuscaUsuarioPorGrupo(int id)
        {
            return _grupoAcessoUsuarioRepository.BuscaUsuarioPorGrupo(id);
        }


        public IEnumerable<GrupoAcessoPermissao> ListaGrupoPorUsuario(int id)
        {
            return _grupoAcessoUsuarioRepository.ListaGrupoPorUsuario(id);
        }

        public IEnumerable<GrupoAcessoPermissao> ListaUsuarioPorGrupo(int id)
        {
            return _grupoAcessoUsuarioRepository.ListaUsuarioPorGrupo(id);
        }
    }
}