namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Cpf", c => c.String(nullable: false, maxLength: 15, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Cpf", c => c.String(nullable: false, maxLength: 11, unicode: false));
        }
    }
}
