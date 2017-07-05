namespace PrjCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class adicionadoGrupoAcessos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoAcesso",
                c => new
                    {
                        GrupoAcessoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoAcessoId);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        PermissaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        GrupoAcesso_GrupoAcessoId = c.Int(),
                    })
                .PrimaryKey(t => t.PermissaoId)
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcesso_GrupoAcessoId)
                .Index(t => t.GrupoAcesso_GrupoAcessoId);
            
            CreateTable(
                "dbo.GrupoAcessosUsuarios",
                c => new
                    {
                        GrupoAcessoId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GrupoAcessoId, t.Id })
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcessoId)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.GrupoAcessoId)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoAcessosUsuarios", "Id", "dbo.Usuario");
            DropForeignKey("dbo.GrupoAcessosUsuarios", "GrupoAcessoId", "dbo.GrupoAcesso");
            DropForeignKey("dbo.Permissao", "GrupoAcesso_GrupoAcessoId", "dbo.GrupoAcesso");
            DropIndex("dbo.GrupoAcessosUsuarios", new[] { "Id" });
            DropIndex("dbo.GrupoAcessosUsuarios", new[] { "GrupoAcessoId" });
            DropIndex("dbo.Permissao", new[] { "GrupoAcesso_GrupoAcessoId" });
            DropTable("dbo.GrupoAcessosUsuarios");
            DropTable("dbo.Permissao");
            DropTable("dbo.GrupoAcesso");
        }
    }
}
