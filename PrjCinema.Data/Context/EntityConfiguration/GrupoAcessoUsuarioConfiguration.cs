
using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    public class GrupoAcessoUsuarioConfiguration : EntityTypeConfiguration<GrupoAcessoUsuario>
    {
        public GrupoAcessoUsuarioConfiguration()
        {
            HasKey(c => c.Id);
        }

    }
}
