using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class DbEntities : DbContext
    {
        public DbEntities(): base("Demo_Vidly") { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Sales> Sales { get; set; }

    }
}