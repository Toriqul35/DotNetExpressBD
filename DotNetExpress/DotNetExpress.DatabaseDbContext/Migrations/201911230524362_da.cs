namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class da : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Product_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropColumn("dbo.Purchases", "Product_Id");
        }
    }
}
