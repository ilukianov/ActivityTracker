using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.ApplicationServices.Implementation;

namespace ActivityTracker.ApplicationServices.Interfaces
{
    public interface IActivityService
    {
        IEnumerable<ActivityDto> GetAllActivities();

        int AddActivity(AddActivityDto addActivityDto);

        ActivityDto GetActivityById(int id);
        void UpdateActivity(ActivityUpdateDto activityDto);
    }
}
