
using System.Data.Entity.ModelConfiguration;

using PrjCinema.Domain.Entities.Relacoes;


namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class AtuaSerieConfiguration: EntityTypeConfiguration<AtuaSerie>
    {
        public AtuaSerieConfiguration()
        {
            HasKey(c => c.Id);

           
        }

    }
}
