using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using luce_MIS4200_1045.Models;

namespace luce_MIS4200_1045.DAL
{
    public class MIS4200Context : DbContext 
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context,luce_MIS4200_1045.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
        // Include each object here. The value inside <> is the name of the class,
        // the value outside should generally be the plural of the class name
        // and is the name used to reference the entity in code
        public DbSet<customerOrder> Orders { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<lineItem> LineItems { get; set; }
        }
}