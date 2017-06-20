
using System.Data.Entity.ModelConfiguration;

using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class AtorConfiguration: EntityTypeConfiguration<Ator>
    {
        public AtorConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c => c.DataNascimento).IsRequired();
            Property(c => c.Nacionalidade).IsRequired();
            
        }

    }
}
