﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Common;

namespace ActivityTracker.Core.Domain
{
    public class Activity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ActivityStatuses Status { get; set; }

        public DateTime StartTime { get; set; }
    }
}
