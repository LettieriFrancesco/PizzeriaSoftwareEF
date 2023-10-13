namespace PizzeriaSoftwareEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clienti",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        DataOrdine = c.DateTime(nullable: false, storeType: "date"),
                        Importo = c.Decimal(nullable: false, storeType: "money"),
                        IndirizzoConsegna = c.String(nullable: false),
                        IdCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Clienti", t => t.IdCliente)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.DettaglioOrdini",
                c => new
                    {
                        IdDettaglio = c.Int(nullable: false, identity: true),
                        IdProdotto = c.Int(nullable: false),
                        Quantita = c.Int(nullable: false),
                        IdOrdine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDettaglio)
                .ForeignKey("dbo.Prodotti", t => t.IdProdotto)
                .ForeignKey("dbo.Ordini", t => t.IdOrdine)
                .Index(t => t.IdProdotto)
                .Index(t => t.IdOrdine);
            
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        IdProdotto = c.Int(nullable: false, identity: true),
                        NomeProdotto = c.String(nullable: false),
                        Costo = c.Decimal(nullable: false, storeType: "money"),
                        TempoConsegna = c.Int(),
                        FotoProdotto = c.String(nullable: false),
                        Ingredienti = c.String(nullable: false),
                        DescrizioneAggiuntiva = c.String(),
                    })
                .PrimaryKey(t => t.IdProdotto);
            
            CreateTable(
                "dbo.NoteOrdini",
                c => new
                    {
                        IdNota = c.Int(nullable: false, identity: true),
                        DescrizioneNota = c.String(nullable: false),
                        IdOrdine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdNota)
                .ForeignKey("dbo.Ordini", t => t.IdOrdine)
                .Index(t => t.IdOrdine);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Username = c.String(nullable: false),
                        PasswordUser = c.String(nullable: false),
                        Ruolo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordini", "IdCliente", "dbo.Clienti");
            DropForeignKey("dbo.NoteOrdini", "IdOrdine", "dbo.Ordini");
            DropForeignKey("dbo.DettaglioOrdini", "IdOrdine", "dbo.Ordini");
            DropForeignKey("dbo.DettaglioOrdini", "IdProdotto", "dbo.Prodotti");
            DropIndex("dbo.NoteOrdini", new[] { "IdOrdine" });
            DropIndex("dbo.DettaglioOrdini", new[] { "IdOrdine" });
            DropIndex("dbo.DettaglioOrdini", new[] { "IdProdotto" });
            DropIndex("dbo.Ordini", new[] { "IdCliente" });
            DropTable("dbo.User");
            DropTable("dbo.NoteOrdini");
            DropTable("dbo.Prodotti");
            DropTable("dbo.DettaglioOrdini");
            DropTable("dbo.Ordini");
            DropTable("dbo.Clienti");
        }
    }
}
