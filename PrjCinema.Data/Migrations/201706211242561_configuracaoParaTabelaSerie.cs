namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configuracaoParaTabelaSerie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filme", "Descricao", c => c.String(nullable: false, maxLength: 3000, unicode: false));
            AlterColumn("dbo.Serie", "Titulo", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Serie", "Descricao", c => c.String(nullable: false, maxLength: 3000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Serie", "Descricao", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Serie", "Titulo", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Filme", "Descricao", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
    }
}
