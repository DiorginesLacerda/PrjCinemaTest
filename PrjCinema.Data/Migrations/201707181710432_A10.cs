namespace PrjCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class A10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Nacionalidade = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 3000, unicode: false),
                        Nacionalidade = c.Int(nullable: false),
                        Duracao = c.String(maxLength: 100, unicode: false),
                        Lancamento = c.DateTime(nullable: false),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Serie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 3000, unicode: false),
                        Nacionalidade = c.Int(nullable: false),
                        QntEpisodio = c.Int(nullable: false),
                        Lancamento = c.DateTime(nullable: false),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Rua = c.String(nullable: false, maxLength: 150, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Uf = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrupoAcesso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        TelaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tela", t => t.TelaId)
                .Index(t => t.TelaId);
            
            CreateTable(
                "dbo.Operacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        NomeOperacao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tela",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Removido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 15, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Genero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtuaFilmes",
                c => new
                    {
                        IdFilmesFK = c.Int(nullable: false),
                        IdAtoresFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdFilmesFK, t.IdAtoresFK })
                .ForeignKey("dbo.Ator", t => t.IdFilmesFK)
                .ForeignKey("dbo.Filme", t => t.IdAtoresFK)
                .Index(t => t.IdFilmesFK)
                .Index(t => t.IdAtoresFK);
            
            CreateTable(
                "dbo.AtuaSeries",
                c => new
                    {
                        IdFilmesFK = c.Int(nullable: false),
                        IdAtoresFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdFilmesFK, t.IdAtoresFK })
                .ForeignKey("dbo.Ator", t => t.IdFilmesFK)
                .ForeignKey("dbo.Serie", t => t.IdAtoresFK)
                .Index(t => t.IdFilmesFK)
                .Index(t => t.IdAtoresFK);
            
            CreateTable(
                "dbo.PermissaoOperacoes",
                c => new
                    {
                        IdPermissoesFK = c.Int(nullable: false),
                        IdOperacoesFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdPermissoesFK, t.IdOperacoesFK })
                .ForeignKey("dbo.Permissao", t => t.IdPermissoesFK)
                .ForeignKey("dbo.Operacao", t => t.IdOperacoesFK)
                .Index(t => t.IdPermissoesFK)
                .Index(t => t.IdOperacoesFK);
            
            CreateTable(
                "dbo.GrupoAcessosPermissoes",
                c => new
                    {
                        IdGrupoAcessosFK = c.Int(nullable: false),
                        IdPermiessoesFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdGrupoAcessosFK, t.IdPermiessoesFK })
                .ForeignKey("dbo.GrupoAcesso", t => t.IdGrupoAcessosFK)
                .ForeignKey("dbo.Permissao", t => t.IdPermiessoesFK)
                .Index(t => t.IdGrupoAcessosFK)
                .Index(t => t.IdPermiessoesFK);
            
            CreateTable(
                "dbo.GrupoAcessosUsuarios",
                c => new
                    {
                        IdGrupoAcessosFK = c.Int(nullable: false),
                        IdUsuariosFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdGrupoAcessosFK, t.IdUsuariosFK })
                .ForeignKey("dbo.GrupoAcesso", t => t.IdGrupoAcessosFK)
                .ForeignKey("dbo.Usuario", t => t.IdUsuariosFK)
                .Index(t => t.IdGrupoAcessosFK)
                .Index(t => t.IdUsuariosFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoAcessosUsuarios", "IdUsuariosFK", "dbo.Usuario");
            DropForeignKey("dbo.GrupoAcessosUsuarios", "IdGrupoAcessosFK", "dbo.GrupoAcesso");
            DropForeignKey("dbo.GrupoAcessosPermissoes", "IdPermiessoesFK", "dbo.Permissao");
            DropForeignKey("dbo.GrupoAcessosPermissoes", "IdGrupoAcessosFK", "dbo.GrupoAcesso");
            DropForeignKey("dbo.Permissao", "TelaId", "dbo.Tela");
            DropForeignKey("dbo.PermissaoOperacoes", "IdOperacoesFK", "dbo.Operacao");
            DropForeignKey("dbo.PermissaoOperacoes", "IdPermissoesFK", "dbo.Permissao");
            DropForeignKey("dbo.AtuaSeries", "IdAtoresFK", "dbo.Serie");
            DropForeignKey("dbo.AtuaSeries", "IdFilmesFK", "dbo.Ator");
            DropForeignKey("dbo.AtuaFilmes", "IdAtoresFK", "dbo.Filme");
            DropForeignKey("dbo.AtuaFilmes", "IdFilmesFK", "dbo.Ator");
            DropIndex("dbo.GrupoAcessosUsuarios", new[] { "IdUsuariosFK" });
            DropIndex("dbo.GrupoAcessosUsuarios", new[] { "IdGrupoAcessosFK" });
            DropIndex("dbo.GrupoAcessosPermissoes", new[] { "IdPermiessoesFK" });
            DropIndex("dbo.GrupoAcessosPermissoes", new[] { "IdGrupoAcessosFK" });
            DropIndex("dbo.PermissaoOperacoes", new[] { "IdOperacoesFK" });
            DropIndex("dbo.PermissaoOperacoes", new[] { "IdPermissoesFK" });
            DropIndex("dbo.AtuaSeries", new[] { "IdAtoresFK" });
            DropIndex("dbo.AtuaSeries", new[] { "IdFilmesFK" });
            DropIndex("dbo.AtuaFilmes", new[] { "IdAtoresFK" });
            DropIndex("dbo.AtuaFilmes", new[] { "IdFilmesFK" });
            DropIndex("dbo.Permissao", new[] { "TelaId" });
            DropTable("dbo.GrupoAcessosUsuarios");
            DropTable("dbo.GrupoAcessosPermissoes");
            DropTable("dbo.PermissaoOperacoes");
            DropTable("dbo.AtuaSeries");
            DropTable("dbo.AtuaFilmes");
            DropTable("dbo.Usuario");
            DropTable("dbo.Tela");
            DropTable("dbo.Operacao");
            DropTable("dbo.Permissao");
            DropTable("dbo.GrupoAcesso");
            DropTable("dbo.Endereco");
            DropTable("dbo.Serie");
            DropTable("dbo.Filme");
            DropTable("dbo.Ator");
        }
    }
}
