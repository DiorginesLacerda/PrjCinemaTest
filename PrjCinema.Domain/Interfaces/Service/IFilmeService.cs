using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Service

{
    public interface IFilmeService : IServiceBase<Filme>
    {
        IEnumerable<Filme> BuscaFilmesPorAtor(int id);
    }
}