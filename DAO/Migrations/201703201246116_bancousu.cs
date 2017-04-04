namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancousu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parceiroes", "Banco_CodBanco", c => c.Int());
            CreateIndex("dbo.Parceiroes", "Banco_CodBanco");
            AddForeignKey("dbo.Parceiroes", "Banco_CodBanco", "dbo.Bancoes", "CodBanco");
            DropColumn("dbo.Parceiroes", "Banco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parceiroes", "Banco", c => c.String());
            DropForeignKey("dbo.Parceiroes", "Banco_CodBanco", "dbo.Bancoes");
            DropIndex("dbo.Parceiroes", new[] { "Banco_CodBanco" });
            DropColumn("dbo.Parceiroes", "Banco_CodBanco");
        }
    }
}
