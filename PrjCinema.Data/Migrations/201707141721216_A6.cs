namespace PrjCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Removido = c.Boolean(nullable: false),
                        NomeOperacao = c.String(maxLength: 100, unicode: false),
                        Permissao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id)
                .Index(t => t.Permissao_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operacao", "Permissao_Id", "dbo.Permissao");
            DropIndex("dbo.Operacao", new[] { "Permissao_Id" });
            DropTable("dbo.Operacao");
        }
    }
}
