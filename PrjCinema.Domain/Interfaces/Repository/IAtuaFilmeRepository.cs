using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IAtuaFilmeRepository : IRepositoryBase<AtuaFilme>
    {
        IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id);

        IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id);

    }
}