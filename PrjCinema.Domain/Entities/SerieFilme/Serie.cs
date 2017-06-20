using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Entities.SerieFilme
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        
        public int QntEpisodio { get; set; }
        public DateTime Lancamento { get; set; }
        public Categoria Categoria { get; set; }
        public virtual IEnumerable<AtuaSerie> AtuaSeries { get; set; }
    }
}
