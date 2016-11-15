using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.Core.Domain;
using AutoMapper;

namespace ActivityTracker.ApplicationServices
{
    public static class Mapper
    {
        private static readonly MapperConfiguration _mapperConfiguration;

        static Mapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Activity, ActivityDto>();
                cfg.CreateMap<ActivityDto, Activity>();
                cfg.CreateMap<AddActivityDto, Activity>().ForMember(m => m.StartTime, opt => opt.UseValue(new DateTime(1753, 1, 1)));
            });
        }

        public static TDestination Map<TSource, TDestination>(TSource obj)
        {
            return _mapperConfiguration.CreateMapper().Map<TDestination>(obj);
        }
    }
}
