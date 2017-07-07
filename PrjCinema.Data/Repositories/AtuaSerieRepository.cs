using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class AtuaSerieRepository : RepositoryBase<AtuaSerie>, IAtuaSerieRepository
    {

        public IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id)
        {
            return GetAll().Where(u => u.AtorId == id);

        }

        public IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id)
        {
            return GetAll().Where(u => u.SerieId == id);
        }
    }
}
