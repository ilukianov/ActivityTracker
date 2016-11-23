using System.Collections.Generic;
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
            AutomaticMigrationDataLossAllowed = true;
        }

    protected override void Seed(ActivityTracker.Core.DAL.EF.ActivityDbContext context)
        {
            context.Activities.AddOrUpdate(m => m.Id,
                new Activity
                {
                    Id = 1,
                    Description = "New Activity #1",
                    Title = "Task number 1",
                    Status = ActivityStatuses.None
                },
                new Activity
                {
                    Id = 2,
                    Title = "some new test task",
                    Description = "description for the new test task",
                    Status = ActivityStatuses.InProgress,
                    TimeSteps = new []
                    {
                        new TimeStep
                        {
                            //Id = 1,
                            StartTime = new DateTime(2016, 11, 14, 21, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 14, 22, 10, 10, DateTimeKind.Utc)
                        },
                        new TimeStep
                        {
                            //Id = 2,
                            StartTime = new DateTime(2016, 11, 16, 09, 10, 10, DateTimeKind.Utc)
                        }
                    }
                },
                new Activity
                {
                    Id = 3,
                    Title = "Task number 3",
                    Description = "description for the test task #3",
                    Status = ActivityStatuses.Stopped,
                    TimeSteps = new[]
                    {
                        new TimeStep
                        {
                            //Id = 3,
                            StartTime = new DateTime(2016, 11, 14, 21, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 14, 22, 10, 10, DateTimeKind.Utc)
                        }
                    }

                },
                new Activity
                {
                    Id = 4,
                    Title = "Task number 4",
                    Description = "description for the test task #4",
                    Status = ActivityStatuses.Stopped,
                    TimeSteps = new[]
                    {
                        new TimeStep
                        {
                            //Id = 4,
                            StartTime = new DateTime(2016, 11, 14, 21, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 14, 22, 10, 10, DateTimeKind.Utc)
                        },
                        new TimeStep
                        {
                            //Id = 5,
                            StartTime = new DateTime(2016, 11, 15, 11, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 15, 12, 17, 10, DateTimeKind.Utc)
                        },
                        new TimeStep
                        {
                            //Id = 6,
                            StartTime = new DateTime(2016, 11, 16, 07, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 16, 08, 17, 10, DateTimeKind.Utc)
                        }
                    }
                },
                new Activity
                {
                    Id = 5,
                    Title = "Task number 5",
                    Description = "description for the test task #5",
                    Status = ActivityStatuses.Completed,
                    TimeSteps = new[]
                    {
                        new TimeStep
                        {
                            //Id = 7,
                            StartTime = new DateTime(2016, 11, 14, 21, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 14, 22, 10, 10, DateTimeKind.Utc)
                        },
                        new TimeStep
                        {
                            //Id = 8,
                            StartTime = new DateTime(2016, 11, 15, 11, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 15, 12, 17, 10, DateTimeKind.Utc)
                        },
                        new TimeStep
                        {
                            //Id = 9,
                            StartTime = new DateTime(2016, 11, 16, 07, 10, 10, DateTimeKind.Utc),
                            StopTime = new DateTime(2016, 11, 16, 08, 17, 10, DateTimeKind.Utc)
                        }
                    }
                }

                );

            context.SaveChanges();
        }
    }
}
