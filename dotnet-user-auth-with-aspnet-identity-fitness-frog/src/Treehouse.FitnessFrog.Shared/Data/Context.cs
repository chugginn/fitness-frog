using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Shared.Data
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Entry> Entries { get; set; }

        // IdentityDbContext has a constructor that takes a string for the database connection,
        // which we have set to 'Context' in Web.config
        public Context()
            : base("Context")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // this line required so Identity-related tables are created
            base.OnModelCreating(modelBuilder);

            // Removing the pluralizing table name convention 
            // so our table names will use our entity class singular names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Using the fluent API to configure entity properties...

            // Configure the string length for the Activity.Name property.
            modelBuilder.Entity<Activity>()
                .Property(a => a.Name)
                .HasMaxLength(100);

            // Configure the precision and scale for the Entry.Duration property.
            modelBuilder.Entity<Entry>()
                .Property(e => e.Duration)
                .HasPrecision(5, 1);
        }
    }
}
