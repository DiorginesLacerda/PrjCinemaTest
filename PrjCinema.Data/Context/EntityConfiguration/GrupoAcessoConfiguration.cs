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
            //HasMany(u => u.Usuarios)
            //    .WithMany(g => g.GrupoAcessos)
            //    .Map(m =>
            //    {
            //        m.MapRightKey("Id");
            //        m.MapLeftKey("Id");
            //        //m.ToTable("GrupoAcessosUsuarios");
            //    });
        }
    }
}

