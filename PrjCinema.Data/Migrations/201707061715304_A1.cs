namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoAcesso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        GrupoAcesso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcesso_Id)
                .Index(t => t.GrupoAcesso_Id);
            
            CreateTable(
                "dbo.GrupoAcessoUsuario",
                c => new
                    {
                        GrupoAcessoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GrupoAcessoId, t.UsuarioId })
                .ForeignKey("dbo.GrupoAcesso", t => t.GrupoAcessoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.GrupoAcessoId)
                .Index(t => t.UsuarioId);
            
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
            DropForeignKey("dbo.GrupoAcessoUsuario", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.GrupoAcessoUsuario", "GrupoAcessoId", "dbo.GrupoAcesso");
            DropForeignKey("dbo.UsuarioGrupoAcesso", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropForeignKey("dbo.UsuarioGrupoAcesso", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Permissao", "GrupoAcesso_Id", "dbo.GrupoAcesso");
            DropIndex("dbo.UsuarioGrupoAcesso", new[] { "GrupoAcesso_Id" });
            DropIndex("dbo.UsuarioGrupoAcesso", new[] { "Usuario_Id" });
            DropIndex("dbo.GrupoAcessoUsuario", new[] { "UsuarioId" });
            DropIndex("dbo.GrupoAcessoUsuario", new[] { "GrupoAcessoId" });
            DropIndex("dbo.Permissao", new[] { "GrupoAcesso_Id" });
            DropTable("dbo.UsuarioGrupoAcesso");
            DropTable("dbo.GrupoAcessoUsuario");
            DropTable("dbo.Permissao");
            DropTable("dbo.GrupoAcesso");
        }
    }
}
