using System;
using System.Collections.Generic;
using System.Linq;
using ActivityTracker.Common;

namespace ActivityTracker.Core.Domain
{
    public class Activity
    {
        /*public Activity()
        {
        }*/

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ActivityStatuses Status { get; set; }

        public virtual ICollection<TimeStep> TimeSteps { get; set; }

        public TimeSpan GetDuration()
        {
            var duration = new TimeSpan();

            var nonEmptySteps = TimeSteps.Where(x => x.StopTime.HasValue);

            return nonEmptySteps.Aggregate(duration, (accumulator, next) =>
                                            accumulator.Add(next.StopTime.Value - next.StartTime));
        }

        public DateTime GetStartTime()
        {
            var startedTimeStep = TimeSteps.FirstOrDefault(x => x.StopTime == null);

            if (startedTimeStep != null)
            {
                return new DateTime(
                    startedTimeStep.StartTime.Year,
                    startedTimeStep.StartTime.Month,
                    startedTimeStep.StartTime.Day,
                    startedTimeStep.StartTime.Hour,
                    startedTimeStep.StartTime.Minute,
                    startedTimeStep.StartTime.Second,
                    startedTimeStep.StartTime.Millisecond,
                    DateTimeKind.Utc
                    );
            }

            return DateTime.MinValue;
        }
    }
}
