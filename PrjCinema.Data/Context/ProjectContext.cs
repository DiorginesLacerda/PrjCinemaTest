
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using PrjCinema.Data.Context.EntityConfiguration;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("ProjectDB_Novo")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<AtuaSerie> AtuaSeries { get; set; }
        public DbSet<AtuaFilme> AtuaFilmes { get; set; }
        public DbSet<GrupoAcesso> GrupoAcessos { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<GrupoAcessoUsuario> GrupoAcessoUsuarios { get; set; }
        public DbSet<GrupoAcessoPermissao> GrupoAcessoPermissoes { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new FilmeConfiguration());
            modelBuilder.Configurations.Add(new SerieConfiguration());
            modelBuilder.Configurations.Add(new AtorConfiguration());
            modelBuilder.Configurations.Add(new AtuaFilmeConfiguration());
            modelBuilder.Configurations.Add(new AtuaSerieConfiguration());
            modelBuilder.Configurations.Add(new GrupoAcessoConfiguration());
            modelBuilder.Configurations.Add(new PermissaoConfiguration());
            modelBuilder.Configurations.Add(new GrupoAcessoUsuarioConfiguration());
            modelBuilder.Configurations.Add(new GrupoAcessoPermissaoConfiguration());

            modelBuilder.Entity<GrupoAcessoUsuario>().HasKey(pv => new { pv.GrupoAcessoId, pv.UsuarioId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GrupoAcessoPermissao>().HasKey(pv => new { pv.GrupoAcessoId, pv.PermissaoId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtuaFilme>().HasKey(pv => new { pv.FilmeId, pv.AtorId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtuaSerie>().HasKey(pv => new { pv.SerieId, pv.AtorId });
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }

}
