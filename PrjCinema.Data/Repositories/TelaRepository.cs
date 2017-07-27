using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class TelaRepository : RepositoryBase<Tela>, ITelaRepository
    {
        public TelaRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}