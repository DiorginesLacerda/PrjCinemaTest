using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class SerieConfiguration : EntityTypeConfiguration<Serie>
    {
        public SerieConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Titulo).IsRequired().HasMaxLength(150);
            Property(c => c.Categoria).IsRequired();
            Property(c => c.Nacionalidade).IsRequired();
            Property(c => c.Descricao).IsRequired().HasMaxLength(3000);
            Property(c => c.Lancamento).IsRequired();
            



        }
    }
}
