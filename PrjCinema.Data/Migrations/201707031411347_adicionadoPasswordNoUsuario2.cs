namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionadoPasswordNoUsuario2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Password", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Password");
        }
    }
}
