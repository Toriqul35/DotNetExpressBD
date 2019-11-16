namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Code");
        }
    }
}
