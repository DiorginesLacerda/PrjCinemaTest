
using System.Data.Entity.ModelConfiguration;

using PrjCinema.Domain.Entities.Relacoes;


namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class AtuaFilmeConfiguration: EntityTypeConfiguration<AtuaFilme>
    {
        public AtuaFilmeConfiguration()
        {
            HasKey(c => c.Id);

           
        }

    }
}
