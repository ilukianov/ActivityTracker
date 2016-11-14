using System.Collections.Generic;
using System.Linq;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.DAL.Repository;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.ApplicationServices
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityService)
        {
            _activityRepository = activityService;
        }

        public IEnumerable<ActivityDto> GetAllActivities()
        {
            var activities = _activityRepository.GetActivities();
            var activityDtos = activities.Select(Mapper.Map<Activity, ActivityDto>);
            return activityDtos;//.MapTo<ActivityDto>;
        }

        public int AddActivity(AddActivityDto addActivityDto)
        {
            var activityToAdd = Mapper.Map<AddActivityDto, Activity>(addActivityDto);
            int newEntityId = _activityRepository.Add(activityToAdd);
            return newEntityId;
        }

        public ActivityDto GetActivityById(int id)
        {
            var activity = _activityRepository.GetActivity(id);
            var activityDto = Mapper.Map<Activity, ActivityDto>(activity);
            return activityDto;//.MapTo<ActivityDto>;
        }
    }
}
