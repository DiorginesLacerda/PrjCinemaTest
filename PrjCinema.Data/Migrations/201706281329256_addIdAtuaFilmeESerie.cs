namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdAtuaFilmeESerie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AtuaFilme", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.AtuaSerie", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AtuaSerie", "Id");
            DropColumn("dbo.AtuaFilme", "Id");
        }
    }
}
