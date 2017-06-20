using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class AtuaSerieService : ServiceBase<AtuaSerie>, IAtuaSerieService
    {
        private readonly IAtuaSerieRepository _atuaSerieRepository;

        public AtuaSerieService(IAtuaSerieRepository atuaSerieRepository)
            :base(atuaSerieRepository)
        {
            _atuaSerieRepository = atuaSerieRepository;
        }

        public IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id)
        {
            return _atuaSerieRepository.BuscaSeriePorAtor(id);
        }

        public IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id)
        {
            return _atuaSerieRepository.BuscaAtorPorSerie(id);
        }
    }
}
