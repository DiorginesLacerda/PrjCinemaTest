using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class OperacaoConfiguration : EntityTypeConfiguration<Operacao>
    {
        public OperacaoConfiguration()
        {
            HasKey(c => c.Id);
        }
    }
}