using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Service
{
    public interface IAtuaSerieService : IServiceBase<AtuaSerie>
    {
        IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id);

        IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id);

    }
}