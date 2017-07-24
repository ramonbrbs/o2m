namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operadoraobrig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Indicadoes", "Operadora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Indicadoes", "Operadora", c => c.String());
        }
    }
}
