using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        IEnumerable<Filme> BuscaFilmesPorAtor(int id);
        
    }
}