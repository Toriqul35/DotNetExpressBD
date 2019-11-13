namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddminLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin_Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Name = c.String(nullable: false),
                        Pin = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Contact", c => c.String());
            AddColumn("dbo.Customers", "Loyolty_Point", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Loyolty_Point");
            DropColumn("dbo.Customers", "Contact");
            DropColumn("dbo.Customers", "Email");
            DropTable("dbo.Admin_Login");
        }
    }
}
