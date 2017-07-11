using System;
using System.Collections.Generic;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.SerieFilme
{
    public class Serie: ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public int QntEpisodio { get; set; }
        public DateTime Lancamento { get; set; }
        public Categoria Categoria { get; set; }
        public virtual ICollection<Ator> SerieAtores { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
