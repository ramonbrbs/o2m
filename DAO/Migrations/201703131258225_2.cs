namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Indicadoes",
                c => new
                    {
                        CodIndicado = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Contato = c.String(nullable: false),
                        Telefone1 = c.String(),
                        Telefone2 = c.String(),
                        Email = c.String(),
                        Operadora = c.String(),
                        ValorLead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdLinhasMoveis = c.Int(nullable: false),
                        QtdLinhasFixas = c.Int(nullable: false),
                        QtdBandaLarga = c.Int(nullable: false),
                        QtdCentraltelefonica = c.Int(nullable: false),
                        QtdLinkDedicado = c.Int(nullable: false),
                        CodParceiro = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodIndicado)
                .ForeignKey("dbo.Parceiroes", t => t.CodParceiro, cascadeDelete: true)
                .Index(t => t.CodParceiro);
            
            CreateTable(
                "dbo.Parceiroes",
                c => new
                    {
                        CodParceiro = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Documento = c.String(),
                        Agencia = c.String(),
                        Banco = c.String(),
                        Email = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.CodParceiro);
            
            CreateTable(
                "dbo.TokenLogins",
                c => new
                    {
                        CodTokenLogin = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        CodParceiro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodTokenLogin)
                .ForeignKey("dbo.Parceiroes", t => t.CodParceiro, cascadeDelete: true)
                .Index(t => t.CodParceiro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TokenLogins", "CodParceiro", "dbo.Parceiroes");
            DropForeignKey("dbo.Indicadoes", "CodParceiro", "dbo.Parceiroes");
            DropIndex("dbo.TokenLogins", new[] { "CodParceiro" });
            DropIndex("dbo.Indicadoes", new[] { "CodParceiro" });
            DropTable("dbo.TokenLogins");
            DropTable("dbo.Parceiroes");
            DropTable("dbo.Indicadoes");
        }
    }
}
