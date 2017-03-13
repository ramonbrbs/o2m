namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parceiroes", "Conta", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parceiroes", "Conta");
        }
    }
}
