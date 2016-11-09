using ActivityTracker.ApplicationServices.Interfaces;
using ActivityTracker.Core.Infrastructure;

namespace ActivityTracker.ApplicationServices.Initialization
{
    public sealed class Initializer : IDoDependencyRegistration
    {
/*        public Initializer()
        {
        }*/

        public void Register()
        {
            DependencyRegistrator.Register<IActivityService, ActivityService>();
        }
    }
}
