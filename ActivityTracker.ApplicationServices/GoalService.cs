using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;

namespace ActivityTracker.ApplicationServices
{
    public sealed class GoalService : IGoalService
    {
        public IEnumerable<GoalDto> GetGoals()
        {
            return new List<GoalDto> {
                new GoalDto
                {
                    Active = true,
                    Id = 1,
                    Title = "Test goal 1",
                    Description = "some description 1"
                },
                new GoalDto
                {
                    Active = true,
                    Id = 2,
                    Title = "Test goal 2",
                    Description = "some description 2"
                }
            };
        }

        public GoalDto GetGoalById(int id)
        {
            return new GoalDto
            {
                Active = true,
                Id = 1,
                Title = "Test goal 1 edit",
                Description = "some description 1 edit"
            };
        }

        public int AddGoal(GoalAddDto goalToAdd)
        {
            return 0;
        }
    }
}
