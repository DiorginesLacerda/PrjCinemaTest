using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface ISerieRepository: IRepositoryBase<Serie>
    {
       
        IEnumerable<Serie> BuscaSeriesPorAtor(int id);
        
    }
}