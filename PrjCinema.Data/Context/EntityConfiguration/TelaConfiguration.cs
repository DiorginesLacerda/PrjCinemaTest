using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class TelaConfiguration: EntityTypeConfiguration<Tela>
    {
        public TelaConfiguration()
        {
            HasKey(c=>c.Id);

            HasMany(u => u.Permissoes);

        }
    }
}