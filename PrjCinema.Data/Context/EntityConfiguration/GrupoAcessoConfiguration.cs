using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    class GrupoAcessoConfiguration : EntityTypeConfiguration<GrupoAcesso>
    {
        public GrupoAcessoConfiguration()
        {
            HasKey(c => c.GrupoAcessoId);

            //cria tabela como relacionamento many to many
            HasMany(u => u.Usuarios)
                .WithMany(g => g.GrupoAcessos)
                .Map(m =>
                {
                    m.MapLeftKey("GrupoAcessoId");
                    m.MapRightKey("Id");
                    m.ToTable("GrupoAcessosUsuarios");
                });
        }
    }
}

