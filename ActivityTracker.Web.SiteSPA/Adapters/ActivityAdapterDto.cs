using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityTracker.Common;

namespace ActivityTracker.Web.SiteSPA.Adapters
{
    public sealed class ActivityAdapterDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ActivityStatuses Status { get; set; }

        public long TimeStamp { get; set; }

        public long Duration { get; set; }
    }
}