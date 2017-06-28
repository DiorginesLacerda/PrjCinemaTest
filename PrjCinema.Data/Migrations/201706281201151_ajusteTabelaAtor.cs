namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteTabelaAtor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ator", "AtuaSeriesId");
            DropColumn("dbo.Ator", "AtuaFilmesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ator", "AtuaFilmesId", c => c.Int(nullable: false));
            AddColumn("dbo.Ator", "AtuaSeriesId", c => c.Int(nullable: false));
        }
    }
}
