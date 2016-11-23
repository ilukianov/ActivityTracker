using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.Infrastructure;
using ActivityTracker.Web.SiteSPA.Adapters;

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
        public IEnumerable<ActivityAdapterDto> Get()
        {
            var activities = _activityService.GetAllActivities();
            var list = activities.Select(Mapper.Map<ActivityDto, ActivityAdapterDto>);
            return list;
            //return _activityService.GetAllActivities().Select(Mapper.Map<ActivityDto, ActivityAdapterDto>);//.ToList();
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
            var mappedAddedItem = Mapper.Map<ActivityDto, ActivityAdapterDto>(addedItem);
            return CreatedAtRoute("DefaultApi", new { Id = addedItem.Id }, mappedAddedItem);
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
        public IHttpActionResult PutActivity([FromBody]IEnumerable<ActivityUpdateDto> activityDtos)
        {
            foreach (var activityDto in activityDtos)
            {
                Debug.WriteLine(activityDto.TimeStamp);
                _activityService.UpdateActivity(activityDto);
            }

            var updateActivities = new List<ActivityAdapterDto>();
            foreach (var activityUpdateDto in activityDtos)
            {
                var dto = _activityService.GetActivityById(activityUpdateDto.Id);
                //dto.Title = dto.Title + "_from_update";
                updateActivities.Add(Mapper.Map<ActivityDto, ActivityAdapterDto>(dto));
            }

            return Ok(updateActivities);
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