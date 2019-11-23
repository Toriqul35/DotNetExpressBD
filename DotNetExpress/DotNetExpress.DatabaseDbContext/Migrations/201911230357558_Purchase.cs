namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Purchases", "PreviousProduct_Id", "dbo.PreviousProducts");
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "CategoryId" });
            DropIndex("dbo.Purchases", new[] { "PreviousProduct_Id" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            AddColumn("dbo.Purchases", "InvoiceNo", c => c.String());
            DropColumn("dbo.Purchases", "Date");
            DropColumn("dbo.Purchases", "InVoice");
            DropColumn("dbo.Purchases", "CategoryId");
            DropColumn("dbo.Purchases", "Code");
            DropColumn("dbo.Purchases", "PreviousProducId");
            DropColumn("dbo.Purchases", "ManufacturedDate");
            DropColumn("dbo.Purchases", "ExpireDate");
            DropColumn("dbo.Purchases", "Quantity");
            DropColumn("dbo.Purchases", "UnitPrice");
            DropColumn("dbo.Purchases", "TotalPrice");
            DropColumn("dbo.Purchases", "PreviousUnitPrice");
            DropColumn("dbo.Purchases", "PreviousMRP");
            DropColumn("dbo.Purchases", "MRP");
            DropColumn("dbo.Purchases", "Remarks");
            DropColumn("dbo.Purchases", "PreviousProduct_Id");
            DropColumn("dbo.Purchases", "Product_Id");
            DropTable("dbo.PreviousProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PreviousProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvialbeQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreiviousUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreiviousMRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Purchases", "Product_Id", c => c.Int());
            AddColumn("dbo.Purchases", "PreviousProduct_Id", c => c.Int());
            AddColumn("dbo.Purchases", "Remarks", c => c.String());
            AddColumn("dbo.Purchases", "MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousMRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "PreviousUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "ManufacturedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "PreviousProducId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Code", c => c.String());
            AddColumn("dbo.Purchases", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "InVoice", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Purchases", "InvoiceNo");
            CreateIndex("dbo.Purchases", "Product_Id");
            CreateIndex("dbo.Purchases", "PreviousProduct_Id");
            CreateIndex("dbo.Purchases", "CategoryId");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "PreviousProduct_Id", "dbo.PreviousProducts", "Id");
            AddForeignKey("dbo.Purchases", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
