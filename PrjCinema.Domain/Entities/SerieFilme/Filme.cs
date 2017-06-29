

using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Entities.SerieFilme
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public string Duracao { get; set; }
        public DateTime Lancamento { get; set; }
        public Categoria Categoria {get; set;}
        public virtual IEnumerable<AtuaFilme> AtuaFilmes { get; set; }
        
    }
}
