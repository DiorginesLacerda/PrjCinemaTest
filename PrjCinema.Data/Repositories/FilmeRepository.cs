using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public List<Serie> GetAllRelation()
        {
            return context.Series
                .Include(x => x.AtuaSeries)
                .Include(x => x.AtuaSeries.Select(atua => atua.Ator))
                .ToList();
        }
    }
}
