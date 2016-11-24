using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.Infrastructure;

namespace ActivityTracker.Web.SiteSPA.Controllers
{
    //[Route("/api/goal")]
    public class GoalController : ApiController
    {
        private IGoalService _goalService;

        public GoalController()
        {
            _goalService = DependencyRegistrator.Resolve<IGoalService>();
        }

        // GET api/<controller>
        [Route("api/goal")]
        //[ResponseType(typeof(GoalDto))]
        public IEnumerable<GoalDto> Get()
        {
            var goals = _goalService.GetGoals();
            return goals;
        }

        // GET api/<controller>/5
        
        [Route("api/goal/{id:int}")]
        [ResponseType(typeof(GoalDto))]
        public GoalDto Get(int id)
        {
            var goals = _goalService.GetGoalById(id);
            return goals;
        }

        // POST api/<controller>d
        [Route("api/goal")]
        [ResponseType(typeof(GoalDto))]
        public GoalDto Post([FromBody] GoalAddDto goalToAdd)
        {
            int id = _goalService.AddGoal(goalToAdd);
            var addedGoal = _goalService.GetGoalById(id);
            return addedGoal;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}