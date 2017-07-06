using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    class PermissaoConfiguration : EntityTypeConfiguration<Permissao>
    {
        public PermissaoConfiguration()
        {
            HasKey(c => c.Id);
        }
        
    }
}
