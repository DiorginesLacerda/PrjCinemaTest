using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class UsuarioConfiguration  : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c => c.Email).IsRequired().HasMaxLength(150);
            Property(c => c.Cpf).IsRequired().HasMaxLength(15);
            Property(c => c.Telefone).IsRequired().HasMaxLength(15);
            Property(c => c.Password).IsRequired();
            
        }
    }
}
