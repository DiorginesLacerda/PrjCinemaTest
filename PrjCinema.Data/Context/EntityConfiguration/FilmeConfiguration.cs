using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class FilmeConfiguration : EntityTypeConfiguration<Filme>
    {
        public FilmeConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Titulo).IsRequired().HasMaxLength(150);
            Property(c => c.Categoria).IsRequired();
            Property(c => c.Nacionalidade).IsRequired();
            Property(c => c.Descricao).IsRequired().HasMaxLength(500);
            Property(c => c.Lancamento).IsRequired();
            



        }
    }
}
