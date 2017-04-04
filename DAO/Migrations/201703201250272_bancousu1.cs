namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancousu1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parceiroes", "Banco_CodBanco", "dbo.Bancoes");
            DropIndex("dbo.Parceiroes", new[] { "Banco_CodBanco" });
            RenameColumn(table: "dbo.Parceiroes", name: "Banco_CodBanco", newName: "CodBanco");
            AlterColumn("dbo.Parceiroes", "CodBanco", c => c.Int(nullable: false));
            CreateIndex("dbo.Parceiroes", "CodBanco");
            AddForeignKey("dbo.Parceiroes", "CodBanco", "dbo.Bancoes", "CodBanco", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parceiroes", "CodBanco", "dbo.Bancoes");
            DropIndex("dbo.Parceiroes", new[] { "CodBanco" });
            AlterColumn("dbo.Parceiroes", "CodBanco", c => c.Int());
            RenameColumn(table: "dbo.Parceiroes", name: "CodBanco", newName: "Banco_CodBanco");
            CreateIndex("dbo.Parceiroes", "Banco_CodBanco");
            AddForeignKey("dbo.Parceiroes", "Banco_CodBanco", "dbo.Bancoes", "CodBanco");
        }
    }
}
