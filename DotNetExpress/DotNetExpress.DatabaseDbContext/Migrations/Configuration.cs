namespace DotNetExpress.DatabaseDbContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetExpress.DatabaseDbContext.DatabaseDbContext.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DotNetExpress.DatabaseDbContext.DatabaseDbContext.ProjectDbContext";
        }

        protected override void Seed(DotNetExpress.DatabaseDbContext.DatabaseDbContext.ProjectDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
