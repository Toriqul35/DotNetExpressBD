namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseAllData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ExpireDate", c => c.DateTime());
            AddColumn("dbo.Purchases", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousMRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Remarks");
            DropColumn("dbo.Purchases", "MRP");
            DropColumn("dbo.Purchases", "PreviousMRP");
            DropColumn("dbo.Purchases", "PreviousUnit");
            DropColumn("dbo.Purchases", "TotalPrice");
            DropColumn("dbo.Purchases", "UnitPrice");
            DropColumn("dbo.Purchases", "Quantity");
            DropColumn("dbo.Purchases", "ExpireDate");
        }
    }
}
