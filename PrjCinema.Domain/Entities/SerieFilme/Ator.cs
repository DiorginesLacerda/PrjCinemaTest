using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Entities.SerieFilme
{
    public class Ator
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual IEnumerable<AtuaSerie> AtuaSeries { get; set; }
        public virtual IEnumerable<AtuaFilme> AtuaFilmes { get; set; }
    }
}
