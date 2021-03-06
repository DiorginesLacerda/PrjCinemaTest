﻿using System.Collections.Generic;
using System.Linq;
using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class AtorRepository : RepositoryBase<Ator>, IAtorRepository
    {
        public AtorRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        //public void Add(Ator obj)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Ator> BuscaAtoresPorFilme(int id)
        {
            //context.Filmes.AsEnumerable().Where(u => u.FilmeAtores.Any(v => v.AtorFilmes.Any(x=>x.Id ==id)));
            return GetAll().Where(u => u.AtorFilmes.Any(x => x.Id == id));
        }

        public IEnumerable<Ator> BuscaAtoresPorSerie(int id)
        {
            return GetAll().Where(u => u.AtorSeries.Any(x => x.Id == id));
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Ator> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Ator GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(Ator obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Ator obj)
        //{
        //    Update(obj);
        //}
    }
}
