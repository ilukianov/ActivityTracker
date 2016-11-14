using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.Repository
{
    public interface IActivityRepository
    {
        int Add(Activity activity);

        IEnumerable<Activity> GetActivities();

        Activity GetActivity(int id);
    }
}
