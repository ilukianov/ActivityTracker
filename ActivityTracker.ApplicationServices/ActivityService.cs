using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;

namespace ActivityTracker.ApplicationServices
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityService _activityService;

        public ActivityService(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IEnumerable<ActivityDto> GetAllActivities()
        {
            return _activityService.GetAllActivities();
        }

        public void AddActivity(AddActivityDto addActivityDto)
        {
            _activityService.AddActivity(addActivityDto);
        }
    }
}
