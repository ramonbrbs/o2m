namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataenvio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicadoes", "DataEnvio", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Indicadoes", "DataEnvio");
        }
    }
}
