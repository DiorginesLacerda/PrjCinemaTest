using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Data.Repositories.ContextFactory;

namespace PrjCinema.Data.Repositories
{
    public class FilmeRepository : RepositoryBase<Filme>,IFilmeRepository
    {
        public FilmeRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        public IEnumerable<Filme> BuscaFilmesPorAtor(int id)
        {
            return GetAll().Where(u => u.FilmeAtores.Any(x => x.Id == id));
        }

        //public void Add(Filme obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Filme> GetAll()
        //{
        //    return GetAll();
        //}

        //public Filme GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(Filme obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Filme obj)
        //{
        //    Update(obj);
        //}

    }
}
