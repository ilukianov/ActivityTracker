using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.Core.Domain;

namespace ActivityTracker.Core.DAL.Repository
{
    public interface IActivityRepository
    {
        void Add(Activity activity);
    }
}
