namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoBancoNovaVida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Nacionalidade = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        AtuaSeriesId = c.Int(nullable: false),
                        AtuaFilmesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtuaFilme",
                c => new
                    {
                        FilmeId = c.Int(nullable: false),
                        AtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmeId, t.AtorId })
                .ForeignKey("dbo.Ator", t => t.AtorId)
                .ForeignKey("dbo.Filme", t => t.FilmeId)
                .Index(t => t.FilmeId)
                .Index(t => t.AtorId);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Nacionalidade = c.Int(nullable: false),
                        Duracao = c.Single(nullable: false),
                        Lancamento = c.DateTime(nullable: false),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtuaSerie",
                c => new
                    {
                        SerieId = c.Int(nullable: false),
                        AtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerieId, t.AtorId })
                .ForeignKey("dbo.Ator", t => t.AtorId)
                .ForeignKey("dbo.Serie", t => t.SerieId)
                .Index(t => t.SerieId)
                .Index(t => t.AtorId);
            
            CreateTable(
                "dbo.Serie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
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
                        Rua = c.String(nullable: false, maxLength: 150, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Uf = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        EnderecoId = c.Int(nullable: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Genero = c.Int(nullable: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.AtuaSerie", "SerieId", "dbo.Serie");
            DropForeignKey("dbo.AtuaSerie", "AtorId", "dbo.Ator");
            DropForeignKey("dbo.AtuaFilme", "FilmeId", "dbo.Filme");
            DropForeignKey("dbo.AtuaFilme", "AtorId", "dbo.Ator");
            DropIndex("dbo.Usuario", new[] { "EnderecoId" });
            DropIndex("dbo.AtuaSerie", new[] { "AtorId" });
            DropIndex("dbo.AtuaSerie", new[] { "SerieId" });
            DropIndex("dbo.AtuaFilme", new[] { "AtorId" });
            DropIndex("dbo.AtuaFilme", new[] { "FilmeId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Serie");
            DropTable("dbo.AtuaSerie");
            DropTable("dbo.Filme");
            DropTable("dbo.AtuaFilme");
            DropTable("dbo.Ator");
        }
    }
}
