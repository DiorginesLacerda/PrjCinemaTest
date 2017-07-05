namespace PrjCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ajusteConfigUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Telefone", c => c.String(nullable: false, maxLength: 15, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Telefone", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
