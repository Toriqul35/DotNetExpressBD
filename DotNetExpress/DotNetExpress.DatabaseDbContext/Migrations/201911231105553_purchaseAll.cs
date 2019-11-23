namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseAll : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "UnitPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "TotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "PreviousUnit", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "PreviousMRP", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "MRP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "PreviousMRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "PreviousUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
