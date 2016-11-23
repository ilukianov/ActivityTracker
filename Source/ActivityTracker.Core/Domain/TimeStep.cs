using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ActivityTracker.Core.Domain
{
    public class TimeStep
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? StopTime { get; set; }
    }
}
