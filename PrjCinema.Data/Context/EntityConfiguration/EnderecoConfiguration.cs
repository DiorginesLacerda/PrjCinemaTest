using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Rua).IsRequired().HasMaxLength(150);
            Property(c => c.Bairro).IsRequired().HasMaxLength(150);
            Property(c => c.Cep).IsRequired().HasMaxLength(8);
            Property(c => c.Uf).IsRequired();
        }

    }
}
