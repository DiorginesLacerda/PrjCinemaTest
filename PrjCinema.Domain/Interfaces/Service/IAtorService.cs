using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Service
    {
    public interface IAtorService : IServiceBase<Ator>
    {
        IEnumerable<Ator> BuscaAtoresPorSerie(int id);
        IEnumerable<Ator> BuscaAtoresPorFilme(int id);

    }
}