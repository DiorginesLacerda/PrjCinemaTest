﻿using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IAtuaSerieRepository : IRepositoryBase<AtuaSerie>
    {
        IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id);

        IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id);

    }
}