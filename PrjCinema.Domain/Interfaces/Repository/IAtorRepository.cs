using System.Collections.Generic;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IAtorRepository : IRepositoryBase<Ator>
    {
        IEnumerable<Ator> BuscaAtoresPorFilme(int id);
        IEnumerable<Ator> BuscaAtoresPorSerie(int id);
    }
}