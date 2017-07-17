using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class OperacaoRepository : RepositoryBase<Operacao>, IOperacaoRepository
    {
        public OperacaoRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}