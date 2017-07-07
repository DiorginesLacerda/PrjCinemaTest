namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GrupoAcessoPermissao", "Id");
            DropColumn("dbo.GrupoAcessoUsuario", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GrupoAcessoUsuario", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.GrupoAcessoPermissao", "Id", c => c.Int(nullable: false));
        }
    }
}
