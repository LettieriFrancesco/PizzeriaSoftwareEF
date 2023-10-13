namespace PizzeriaSoftwareEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndirizzoCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clienti", "IndirizzoCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clienti", "IndirizzoCliente");
        }
    }
}
