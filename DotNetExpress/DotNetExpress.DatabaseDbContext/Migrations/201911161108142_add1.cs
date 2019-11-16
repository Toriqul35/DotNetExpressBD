namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryName", c => c.String());
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.String());
            DropColumn("dbo.Products", "CategoryName");
        }
    }
}
