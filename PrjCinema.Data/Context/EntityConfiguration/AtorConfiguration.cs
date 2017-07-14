
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

            //cria tabela como relacionamento many to many
            HasMany(u => u.AtorFilmes)
                .WithMany(g => g.FilmeAtores)
                .Map(m =>
                {
                    m.MapRightKey("IdAtoresFK");
                    m.MapLeftKey("IdFilmesFK");
                    m.ToTable("AtuaFilmes");
                });

            //cria tabela como relacionamento many to many
            HasMany(u => u.AtorSeries)
                .WithMany(g => g.SerieAtores)
                .Map(m =>
                {
                    m.MapRightKey("IdAtoresFK");
                    m.MapLeftKey("IdFilmesFK");
                    m.ToTable("AtuaSeries");
                });

            
        }

    }
}
