namespace PrjCinema.Data.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ator", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Filme", "Titulo", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Filme", "Descricao", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filme", "Descricao", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Filme", "Titulo", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Ator", "Nome", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
