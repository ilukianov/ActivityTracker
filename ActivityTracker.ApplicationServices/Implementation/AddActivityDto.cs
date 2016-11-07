using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTracker.ApplicationServices.Implementation
{
    public sealed class AddActivityDto
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
