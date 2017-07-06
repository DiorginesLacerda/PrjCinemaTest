namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissao", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropIndex("dbo.Permissao", new[] { "GrupoAcesso_Id" });
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
            
            DropColumn("dbo.Permissao", "GrupoAcesso_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissao", "GrupoAcesso_Id", c => c.Int());
            DropForeignKey("dbo.PermissaoGrupoAcesso", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropForeignKey("dbo.PermissaoGrupoAcesso", "Permissao_Id", "dbo.Permissao");
            DropIndex("dbo.PermissaoGrupoAcesso", new[] { "GrupoAcesso_Id" });
            DropIndex("dbo.PermissaoGrupoAcesso", new[] { "Permissao_Id" });
            DropTable("dbo.PermissaoGrupoAcesso");
            CreateIndex("dbo.Permissao", "GrupoAcesso_Id");
            AddForeignKey("dbo.Permissao", "GrupoAcesso_Id", "dbo.GrupoAcesso", "Id");
        }
    }
}
