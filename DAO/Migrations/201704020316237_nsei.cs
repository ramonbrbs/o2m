namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nsei : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parceiroes", "Documento", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parceiroes", "Documento", c => c.String());
        }
    }
}
