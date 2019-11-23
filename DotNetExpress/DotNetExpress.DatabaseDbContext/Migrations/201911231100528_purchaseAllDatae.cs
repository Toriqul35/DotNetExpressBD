namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseAllDatae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ManufactureDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ManufactureDate");
        }
    }
}
