using ActivityTracker.Core.DAL.EF.Repositories;
using ActivityTracker.Core.DAL.Repository;
using ActivityTracker.Core.Infrastructure;

namespace ActivityTracker.Core.DAL.EF.Initialization
{
    public sealed class Initializer : IDoDependencyRegistration
    {
/*        public Initializer()
        {
        }*/

        public void Register()
        {
            DependencyRegistrator.Register<IActivityRepository, ActivityRepository>();
        }
    }
}
