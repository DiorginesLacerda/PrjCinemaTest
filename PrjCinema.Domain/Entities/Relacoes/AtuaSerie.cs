using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Entities.Relacoes
{
    public class AtuaSerie
    {
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
        public int AtorId { get; set; }
        public virtual Ator Ator { get; set; }
    }
}
