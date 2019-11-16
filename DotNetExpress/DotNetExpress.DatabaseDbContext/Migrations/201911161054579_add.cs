namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.String());
            DropColumn("dbo.Products", "CategoryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryCode", c => c.String());
            DropColumn("dbo.Products", "CategoryId");
        }
    }
}
