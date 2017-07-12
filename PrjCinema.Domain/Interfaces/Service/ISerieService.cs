using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Service
    {
    public interface ISerieService : IServiceBase<Serie>
    {
        IEnumerable<Serie> BuscaSeriesPorAtor(int id);
    }
}