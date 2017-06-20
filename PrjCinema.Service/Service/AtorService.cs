using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class AtorService : ServiceBase<Ator>, IAtorService
    {
        private readonly IAtorRepository _atorRepository;

        public AtorService(IAtorRepository atorRepository)
            :base (atorRepository)
        {
            _atorRepository = atorRepository;
        }
    }
}
