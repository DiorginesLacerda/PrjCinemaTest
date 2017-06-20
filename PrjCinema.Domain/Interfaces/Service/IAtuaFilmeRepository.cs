using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IAtuaFilmeService : IServiceBase<AtuaFilme>
    {
        IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id);

        IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id);

    }
}