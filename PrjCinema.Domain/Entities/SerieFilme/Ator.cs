using System;
using System.Collections.Generic;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.SerieFilme
{
    public class Ator : ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string Nome { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Serie> AtorSeries { get; set; }
        public virtual ICollection<Filme> AtorFilmes { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
