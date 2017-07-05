using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IAtuaFilmeService : IServiceBase<AtuaFilme>
    {
        IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id);

        IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id);

    }
}