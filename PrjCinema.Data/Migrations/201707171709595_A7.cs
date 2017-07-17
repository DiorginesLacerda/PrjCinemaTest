namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operacao", "Permissao_Id", "dbo.Permissao");
            DropIndex("dbo.Operacao", new[] { "Permissao_Id" });
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
            
            DropColumn("dbo.Operacao", "Permissao_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operacao", "Permissao_Id", c => c.Int());
            DropForeignKey("dbo.PermissaoOperacoes", "IdOperacoesFK", "dbo.Operacao");
            DropForeignKey("dbo.PermissaoOperacoes", "IdPermissoesFK", "dbo.Permissao");
            DropIndex("dbo.PermissaoOperacoes", new[] { "IdOperacoesFK" });
            DropIndex("dbo.PermissaoOperacoes", new[] { "IdPermissoesFK" });
            DropTable("dbo.PermissaoOperacoes");
            CreateIndex("dbo.Operacao", "Permissao_Id");
            AddForeignKey("dbo.Operacao", "Permissao_Id", "dbo.Permissao", "Id");
        }
    }
}
