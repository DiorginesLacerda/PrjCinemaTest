using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class AtorRepository: RepositoryBase<Ator>, IAtorRepository
    {
        public IEnumerable<Ator> BuscaAtoresPorFilme(int id)
        {
            //context.Filmes.AsEnumerable().Where(u => u.FilmeAtores.Any(v => v.AtorFilmes.Any(x=>x.Id ==id)));
            return GetAll().Where(u => u.AtorFilmes.Any(x => x.Id == id));
        }



        public IEnumerable<Ator> BuscaAtoresPorSerie(int id)
        {
            return GetAll().Where(u => u.AtorSeries.Any(x => x.Id == id));
        }
    }
}
