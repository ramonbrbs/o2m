namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bancoes",
                c => new
                    {
                        CodBanco = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CodBacen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodBanco);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bancoes");
        }
    }
}
