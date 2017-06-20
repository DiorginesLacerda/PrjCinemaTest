using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class AtuaFilmeRepository: RepositoryBase<AtuaFilme>, IAtuaFilmeRepository
    {
     
        public IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id)
        {
            return GetAll().Where(u => u.AtorId == id);
            
        }

        public IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id)
        {
            return GetAll().Where(u => u.FilmeId == id);
        }
    }
}
