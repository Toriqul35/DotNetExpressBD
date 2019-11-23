namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchaup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseSupplierId", "dbo.PurchaseSuppliers");
            DropForeignKey("dbo.PurchaseSuppliers", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseSupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseSuppliers", new[] { "SupplierId" });
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.PurchaseSuppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseSuppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(nullable: false, maxLength: 10),
                        Date = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufacturedDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        PurchaseSupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PurchaseSuppliers", "SupplierId");
            CreateIndex("dbo.PurchaseDetails", "ProductId");
            CreateIndex("dbo.PurchaseDetails", "PurchaseSupplierId");
            AddForeignKey("dbo.PurchaseSuppliers", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "PurchaseSupplierId", "dbo.PurchaseSuppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
