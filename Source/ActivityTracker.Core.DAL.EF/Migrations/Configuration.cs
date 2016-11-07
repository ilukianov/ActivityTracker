using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ActivityTracker.Core.DAL.EF.ActivityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ActivityTracker.Core.DAL.EF.ActivityDbContext context)
        {
            context.Activities.AddOrUpdate(m => m.Id,
                new Activity
                {
                    Id = 1,
                    Description = "New Activity #1",
                    Title = "Task number 1"
                },
                new Activity
                {
                    Id = 2,
                    Title = "some new test task",
                    Description = "description for the new test task"
                }
                
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
