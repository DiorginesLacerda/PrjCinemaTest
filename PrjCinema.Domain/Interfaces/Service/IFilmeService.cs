using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Interfaces.Service

{
    public interface IFilmeService : IFilmeRepository
    {
        IEnumerable<Filme> BuscaFilmesPorAtor(int id);
    }
}