using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.EF
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext() : base("DefaultConnection")
        {
            //Configuration.ProxyCreationEnabled = false;
            Debug.Write(Database.Connection.ConnectionString);
        }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("dbo");

            builder.Entity<Activity>()
                .HasKey(a => a.Id);

            builder.Entity<TimeStep>()
                .HasKey(t => t.Id)
                .HasRequired(t => t.Activity)
                .WithMany(a => a.TimeSteps)
                .HasForeignKey(t => t.ActivityId);
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<TimeStep> TimeSteps { get; set; }
    }
}
