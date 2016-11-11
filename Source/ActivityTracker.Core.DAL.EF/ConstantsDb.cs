using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTracker.Core.DAL.EF
{
    public static class ConstantsDb
    {
        public static DateTime SqlDbMinDateTime => (DateTime) SqlDateTime.MinValue;
    }
}
