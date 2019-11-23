namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchasedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Date");
        }
    }
}
