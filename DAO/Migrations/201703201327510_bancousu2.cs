namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancousu2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Indicadoes", "QtdLinhasMoveis", c => c.Int());
            AlterColumn("dbo.Indicadoes", "QtdLinhasFixas", c => c.Int());
            AlterColumn("dbo.Indicadoes", "QtdBandaLarga", c => c.Int());
            AlterColumn("dbo.Indicadoes", "QtdCentraltelefonica", c => c.Int());
            AlterColumn("dbo.Indicadoes", "QtdLinkDedicado", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Indicadoes", "QtdLinkDedicado", c => c.Int(nullable: false));
            AlterColumn("dbo.Indicadoes", "QtdCentraltelefonica", c => c.Int(nullable: false));
            AlterColumn("dbo.Indicadoes", "QtdBandaLarga", c => c.Int(nullable: false));
            AlterColumn("dbo.Indicadoes", "QtdLinhasFixas", c => c.Int(nullable: false));
            AlterColumn("dbo.Indicadoes", "QtdLinhasMoveis", c => c.Int(nullable: false));
        }
    }
}
