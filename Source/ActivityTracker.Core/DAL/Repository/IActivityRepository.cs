using System.Collections.Generic;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.Repository
{
    public interface IActivityRepository
    {
        int Add(Activity activity);

        IEnumerable<Activity> GetActivities();

        Activity GetActivity(int id);

        void Update(Activity activity);
    }
}
