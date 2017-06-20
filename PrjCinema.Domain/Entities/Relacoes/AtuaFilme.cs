using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Domain.Entities.Relacoes
{
    public class AtuaFilme
    {
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        public int AtorId { get; set; }
        public virtual Ator Ator { get; set; }
    }
}
