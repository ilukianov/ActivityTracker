using System.Collections.Generic;
using ActivityTracker.ApplicationServices.Implementation;

namespace ActivityTracker.ApplicationServices.Interfaces
{
    public interface IGoalService
    {
        IEnumerable<GoalDto> GetGoals();

        GoalDto GetGoalById(int id);

        int AddGoal(GoalAddDto goalToAdd);
    }
}