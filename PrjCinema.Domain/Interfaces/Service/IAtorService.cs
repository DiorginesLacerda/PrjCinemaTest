using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Interfaces.Service
    {
    public interface IAtorService : IAtorRepository
    {
        IEnumerable<Ator> BuscaAtoresPorSerie(int id);
        IEnumerable<Ator> BuscaAtoresPorFilme(int id);

    }
}