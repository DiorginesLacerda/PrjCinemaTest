using System.Data.Entity.ModelConfiguration;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Data.Context.EntityConfiguration
{
    class GrupoAcessoConfiguration : EntityTypeConfiguration<GrupoAcesso>
    {
        public GrupoAcessoConfiguration()
        {
            HasKey(c => c.Id);

            //cria tabela como relacionamento many to many
            HasMany(u => u.Usuarios)
                .WithMany(g => g.GrupoAcesso)
                .Map(m =>
                {
                    m.MapRightKey("IdUsuariosFK");
                    m.MapLeftKey("IdGrupoAcessosFK");
                    m.ToTable("GrupoAcessosUsuarios");
                });

            //cria tabela como relacionamento many to many
            HasMany(u => u.Permissoes)
                .WithMany(g => g.GrupoAcesso)
                .Map(m =>
                {
                    m.MapRightKey("IdPermiessoesFK");
                    m.MapLeftKey("IdGrupoAcessosFK");
                    m.ToTable("GrupoAcessosPermissoes");
                });
        }
    }
}

