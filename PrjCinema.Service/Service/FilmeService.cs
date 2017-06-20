using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class FilmeService: ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            :base(filmeRepository)
        {
            _filmeRepository = filmeRepository;

        }
    }
}
