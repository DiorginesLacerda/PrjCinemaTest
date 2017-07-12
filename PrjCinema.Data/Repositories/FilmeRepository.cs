using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class FilmeRepository: RepositoryBase<Filme>, IFilmeRepository
    {
       
        public IEnumerable<Filme> BuscaFilmesPorAtor(int id)
        {
            return GetAll().Where(u => u.FilmeAtores.Any(x => x.Id == id));
        }

       

    }
}
