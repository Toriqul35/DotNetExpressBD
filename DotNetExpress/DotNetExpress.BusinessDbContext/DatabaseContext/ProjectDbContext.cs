using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using DotNetExpress.Model.Model;

namespace DotNetExpress.DatabaseContext.DadabaseContext
{
    public class BuisnessDbContext : DbContext
    {

        public BuisnessDbContext()
        {
            Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        }
        public DbSet<Category> categories { set; get; }
        //public DbSet<Customer> Customers { set; get; }

    }
}
