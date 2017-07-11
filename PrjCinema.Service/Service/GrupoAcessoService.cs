using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class GrupoAcessoService : ServiceBase<GrupoAcesso>, IGrupoAcessoService
    {
        private readonly IGrupoAcessoRepository _grupoAcessoRepository;
        public GrupoAcessoService(IGrupoAcessoRepository grupoAcessoRepository)
            : base(grupoAcessoRepository)
        {
            _grupoAcessoRepository = grupoAcessoRepository;
        }
    }
}