using System.Data.SqlTypes;
using ActivityTracker.Common;
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
                    Title = "Task number 1",
                    StarTime = new DateTime(1753, 1, 1),
                    Status = ActivityStatuses.None
                },
                new Activity
                {
                    Id = 2,
                    Title = "some new test task",
                    Description = "description for the new test task",
                    StarTime = DateTime.Now,
                    Status = ActivityStatuses.InProgress
                },
                new Activity
                {
                    Id = 3,
                    Title = "Task number 3",
                    Description = "description for the test task #3",
                    StarTime = DateTime.Now,
                    Status = ActivityStatuses.InProgress
                },
                new Activity
                {
                    Id = 4,
                    Title = "Task number 4",
                    Description = "description for the test task #4",
                    StarTime = DateTime.Now,
                    Status = ActivityStatuses.Stopped
                },
                new Activity
                {
                    Id = 5,
                    Title = "Task number 5",
                    Description = "description for the test task #5",
                    StarTime = DateTime.Now,
                    Status = ActivityStatuses.Done
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
