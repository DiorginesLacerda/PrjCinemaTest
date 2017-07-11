namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasMtM : DbMigration
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
                "dbo.FilmeAtor",
                c => new
                    {
                        Filme_Id = c.Int(nullable: false),
                        Ator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Filme_Id, t.Ator_Id })
                .ForeignKey("dbo.Filme", t => t.Filme_Id)
                .ForeignKey("dbo.Ator", t => t.Ator_Id)
                .Index(t => t.Filme_Id)
                .Index(t => t.Ator_Id);
            
            CreateTable(
                "dbo.SerieAtor",
                c => new
                    {
                        Serie_Id = c.Int(nullable: false),
                        Ator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Serie_Id, t.Ator_Id })
                .ForeignKey("dbo.Serie", t => t.Serie_Id)
                .ForeignKey("dbo.Ator", t => t.Ator_Id)
                .Index(t => t.Serie_Id)
                .Index(t => t.Ator_Id);
            
            CreateTable(
                "dbo.PermissaoGrupoAcesso",
                c => new
                    {
                        Permissao_Id = c.Int(nullable: false),
                        GrupoAcesso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permissao_Id, t.GrupoAcesso_Id })
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id)
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcesso_Id)
                .Index(t => t.Permissao_Id)
                .Index(t => t.GrupoAcesso_Id);
            
            CreateTable(
                "dbo.UsuarioGrupoAcesso",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        GrupoAcesso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.GrupoAcesso_Id })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcesso_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.GrupoAcesso_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioGrupoAcesso", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropForeignKey("dbo.UsuarioGrupoAcesso", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.PermissaoGrupoAcesso", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropForeignKey("dbo.PermissaoGrupoAcesso", "Permissao_Id", "dbo.Permissao");
            DropForeignKey("dbo.SerieAtor", "Ator_Id", "dbo.Ator");
            DropForeignKey("dbo.SerieAtor", "Serie_Id", "dbo.Serie");
            DropForeignKey("dbo.FilmeAtor", "Ator_Id", "dbo.Ator");
            DropForeignKey("dbo.FilmeAtor", "Filme_Id", "dbo.Filme");
            DropIndex("dbo.UsuarioGrupoAcesso", new[] { "GrupoAcesso_Id" });
            DropIndex("dbo.UsuarioGrupoAcesso", new[] { "Usuario_Id" });
            DropIndex("dbo.PermissaoGrupoAcesso", new[] { "GrupoAcesso_Id" });
            DropIndex("dbo.PermissaoGrupoAcesso", new[] { "Permissao_Id" });
            DropIndex("dbo.SerieAtor", new[] { "Ator_Id" });
            DropIndex("dbo.SerieAtor", new[] { "Serie_Id" });
            DropIndex("dbo.FilmeAtor", new[] { "Ator_Id" });
            DropIndex("dbo.FilmeAtor", new[] { "Filme_Id" });
            DropTable("dbo.UsuarioGrupoAcesso");
            DropTable("dbo.PermissaoGrupoAcesso");
            DropTable("dbo.SerieAtor");
            DropTable("dbo.FilmeAtor");
            DropTable("dbo.Usuario");
            DropTable("dbo.Permissao");
            DropTable("dbo.GrupoAcesso");
            DropTable("dbo.Endereco");
            DropTable("dbo.Serie");
            DropTable("dbo.Filme");
            DropTable("dbo.Ator");
        }
    }
}
