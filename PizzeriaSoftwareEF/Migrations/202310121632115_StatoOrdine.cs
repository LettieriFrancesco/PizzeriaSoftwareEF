namespace PizzeriaSoftwareEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatoOrdine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordini", "StatoOrdine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ordini", "StatoOrdine");
        }
    }
}
