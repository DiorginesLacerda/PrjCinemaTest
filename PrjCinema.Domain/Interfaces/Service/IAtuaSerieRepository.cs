using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IAtuaSerieService : IRepositoryBase<AtuaSerie>
    {
        IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id);

        IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id);

    }
}