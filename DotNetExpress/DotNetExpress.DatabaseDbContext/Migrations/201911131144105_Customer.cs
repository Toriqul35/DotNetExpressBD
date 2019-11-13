namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Code");
        }
    }
}
