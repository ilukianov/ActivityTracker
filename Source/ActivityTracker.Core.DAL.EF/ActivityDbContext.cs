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
            Debug.Write(Database.Connection.ConnectionString);
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
