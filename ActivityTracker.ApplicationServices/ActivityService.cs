using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Common;
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
            var activities = _activityRepository.GetActivities().ToList();
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

        public void UpdateActivity(ActivityUpdateDto activityUpdateDto)
        {
            var activity = _activityRepository.GetActivity(activityUpdateDto.Id);
            MapToEntity(activityUpdateDto, activity);
            UpdateTimeSteps(activityUpdateDto, activity);

            _activityRepository.Update(activity);
        }

        private void UpdateTimeSteps(ActivityUpdateDto activityUpdateDto, Activity activity)
        {
            switch (activityUpdateDto.Status)
            {
                case ActivityStatuses.InProgress:
                    AddNewItemToTimeSteps(activity, activityUpdateDto);
                    break;

                case ActivityStatuses.Stopped:
                    CloseOpenedTimeStep(activity, activityUpdateDto);
                    break;

                case ActivityStatuses.Completed:
                    CloseOpenedTimeStepIfAny(activity, activityUpdateDto);
                    break;
            }
        }

        private void CloseOpenedTimeStepIfAny(Activity activity, ActivityUpdateDto activityUpdateDto)
        {
            if (activity.TimeSteps.Any(ts => ts.StopTime.HasValue == false))
            {
                CloseOpenedTimeStep(activity, activityUpdateDto);
            }
        }

        private void AddNewItemToTimeSteps(Activity activity, ActivityUpdateDto activityUpdateDto)
        {
            activity.TimeSteps.Add(new TimeStep
            {
                Activity = activity,
                ActivityId = activity.Id,
                StartTime = activityUpdateDto.TimeStamp.ToUniversalTime()
            });
        }

        private void CloseOpenedTimeStep(Activity activity, ActivityUpdateDto activityUpdateDto)
        {
            var openedTimeStep = activity.TimeSteps.First(ts => ts.StopTime.HasValue == false);
            if (openedTimeStep == null)
            {
                // TODO throw spec ex
                throw new InvalidOperationException();
            }

            openedTimeStep.StopTime = activityUpdateDto.TimeStamp.ToUniversalTime();
        }

        private void MapToEntity(ActivityUpdateDto activityUpdateDto, Activity activity)
        {
            activity.Title = activityUpdateDto.Title;
            activity.Description = activityUpdateDto.Description;
            activity.Status = activityUpdateDto.Status;
        }
    }
}
