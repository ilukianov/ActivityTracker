using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public int Add(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();

            return activity.Id;
        }

        public IEnumerable<Activity> GetActivities()
        {
            return _context.Activities;
        }

        public Activity GetActivity(int id)
        {
            return _context.Activities.Find(id);
        }

        public void Update(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
