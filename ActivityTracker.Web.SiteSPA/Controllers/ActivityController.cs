using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Description;
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

        [ResponseType(typeof(ActivityDto))]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]AddActivityDto activityDto)
        {
            int id = _activityService.AddActivity(activityDto);
            var addedItem = _activityService.GetActivityById(id);
            return CreatedAtRoute("DefaultApi", new { Id = addedItem.Id }, addedItem);
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

        [Route("api/activity/changestatus")]
        // PUT api/<controller>/5
        public void PutActivity([FromBody]IEnumerable<ActivityDto> activityDtos)
        {
            foreach (var activityDto in activityDtos)
            {
                _activityService.UpdateActivity(activityDto);
            }
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