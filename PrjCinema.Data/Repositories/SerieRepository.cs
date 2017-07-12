using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {

        public IEnumerable<Serie> BuscaSeriesPorAtor(int id)
        {
            return GetAll().Where(u => u.SerieAtores.Any(x => x.Id == id));
        }
        //public List<Serie> GetAllRelation()
        //{
        //    return context.Series
        //        .Include(x => x.AtuaSeries)
        //        .Include(x => x.AtuaSeries.Select(atua => atua.Ator))
        //        .ToList();
        //}
    }
}
