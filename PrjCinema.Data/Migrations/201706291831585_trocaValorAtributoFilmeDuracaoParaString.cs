namespace PrjCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class trocaValorAtributoFilmeDuracaoParaString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filme", "Duracao", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filme", "Duracao", c => c.Single(nullable: false));
        }
    }
}
