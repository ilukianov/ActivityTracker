using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Common;

namespace ActivityTracker.ApplicationServices.Implementation
{
    public sealed class ActivityStatusChangeDto
    {
        public int Id { get; set; }

        public ActivityStatuses Status { get; set; }
    }
}
