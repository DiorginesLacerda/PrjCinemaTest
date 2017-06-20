using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class SerieService: ServiceBase<Serie>, ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
            :base(serieRepository)
        {
            _serieRepository = serieRepository;
        }
    }
}
