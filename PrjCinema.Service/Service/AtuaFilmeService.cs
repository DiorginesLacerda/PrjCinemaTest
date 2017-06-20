using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class AtuaFilmeService : ServiceBase<AtuaFilme>, IAtuaFilmeService
    {
        private readonly IAtuaFilmeRepository _atuaFilmeRepository;

        public AtuaFilmeService(IAtuaFilmeRepository atuaFilmeRepository)
            :base(atuaFilmeRepository)
        {
            _atuaFilmeRepository = atuaFilmeRepository;
        }

        public IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id)
        {
            return _atuaFilmeRepository.BuscaFilmePorAtor(id);
        }

        public IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id)
        {
            return _atuaFilmeRepository.BuscaAtorPorFilme(id);
        }
    }
}
