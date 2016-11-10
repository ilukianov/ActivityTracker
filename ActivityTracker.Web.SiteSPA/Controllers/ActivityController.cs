using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.Infrastructure;

namespace ActivityTracker.Web.SiteSPA.Controllers
{
    public class ActivityController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ActivityDto> Get()
        {
            var activityRepo = DependencyRegistrator.Resolve<IActivityService>();
            return activityRepo.GetAllActivities();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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