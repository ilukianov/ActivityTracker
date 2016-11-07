using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Core.DAL.Repository;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.EF.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityDbContext _context;

        public ActivityRepository(ActivityDbContext context)
        {
            _context = context;
        }

        public void Add(Activity activity)
        {
            _context.Activities.Add(activity);
        }

        public IEnumerable<Activity> GetActivities()
        {
            return _context.Activities;
        }
    }
}
