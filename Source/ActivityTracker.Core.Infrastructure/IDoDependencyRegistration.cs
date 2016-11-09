using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActivityTracker.Core.Infrastructure
{
    public interface IDoDependencyRegistration
    {
        void Register();
    }
}
