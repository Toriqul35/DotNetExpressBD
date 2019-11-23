using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using DotNetExpress.Model.Model;

namespace DotNetExpress.DatabaseDbContext.DatabaseDbContext
{
    public class ProjectDbContext : DbContext
    {
        //public ProjectDbContext()
        //{

        //    Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        //}
        public DbSet<Admin_Login> Admin_Logins { set; get; }
        public DbSet<Category> categories { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<Purchase> Purchases{ set; get; }



    }
}