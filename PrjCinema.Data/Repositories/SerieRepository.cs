using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class SerieRepository : RepositoryBase<Serie>,ISerieRepository
    {
        public SerieRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        public IEnumerable<Serie> BuscaSeriesPorAtor(int id)
        {
            return GetAll().Where(u => u.SerieAtores.Any(x => x.Id == id));
        }
        ////public List<Serie> GetAllRelation()
        ////{
        ////    return context.Series
        ////        .Include(x => x.AtuaSeries)
        ////        .Include(x => x.AtuaSeries.Select(atua => atua.Ator))
        ////        .ToList();
        ////}

        //public void Add(Serie obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Serie> GetAll()
        //{
        //    return GetAll();
        //}

        //public Serie GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(Serie obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Serie obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
