using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Interfaces.Service
    {
    public interface ISerieService : ISerieRepository
    {
        IEnumerable<Serie> BuscaSeriesPorAtor(int id);
    }
}