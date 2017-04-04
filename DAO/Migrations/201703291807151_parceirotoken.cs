namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parceirotoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parceiroes", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parceiroes", "Token");
        }
    }
}
