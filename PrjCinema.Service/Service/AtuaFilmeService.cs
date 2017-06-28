using System.Collections.Generic;
using System.Linq;
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

        public bool IsAtuacaoExiste(AtuaFilme atuaFilme)
        {

            if (_atuaFilmeRepository.GetAll().Any(u => u.FilmeId == atuaFilme.FilmeId && u.AtorId == atuaFilme.AtorId))
            {
                return true;
            }
            return false;
        }
    }
}
