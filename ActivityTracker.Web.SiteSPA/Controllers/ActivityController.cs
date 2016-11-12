using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.Infrastructure;

namespace ActivityTracker.Web.SiteSPA.Controllers
{
    public class ActivityController : ApiController
    {
        private readonly IActivityService _activityService;

        public ActivityController()
        {
            _activityService = DependencyRegistrator.Resolve<IActivityService>();
        }

        // GET api/<controller>
        public IEnumerable<ActivityDto> Get()
        {
            return _activityService.GetAllActivities();//.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]AddActivityDto activityDto)
        {
            _activityService.AddActivity(activityDto);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ActivityDto activityDto, string typeOfAction)
        {
            Debug.WriteLine(typeOfAction);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ActivityDto activityDto)
        {
            Debug.WriteLine(id);
        }

        [Route("api/activity/changestatus/{id:int}")]
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ActivityStatusChangeDto activityDto)
        {
            Debug.WriteLine(id);
        }

        [Route("api/activity/changetitle/{id:int}")]
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ActivityFieldChangeDto activityDto)
        {
            Debug.WriteLine(id);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}