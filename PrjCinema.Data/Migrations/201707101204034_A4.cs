namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "Perfil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Perfil", c => c.Int(nullable: false));
        }
    }
}
