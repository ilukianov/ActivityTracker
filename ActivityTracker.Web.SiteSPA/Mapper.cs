using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityTracker.ApplicationServices.Implementation;
using ActivityTracker.Web.SiteSPA.Adapters;
using AutoMapper;

namespace ActivityTracker.Web.SiteSPA
{
    public static class Mapper
    {
        private static readonly MapperConfiguration _mapperConfiguration;

        static Mapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ActivityDto, ActivityAdapterDto>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(x => x.Duration.TotalMilliseconds))
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(x => x.TimeStamp.ToUniversalTime().Subtract(
                                                                            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                                                            ).TotalMilliseconds));
                //cfg.CreateMap<ActivityDto, Activity>();
                //cfg.CreateMap<AddActivityDto, Activity>()
                //.ForMember(dest => dest.TimeSteps, opt => opt.UseValue(new TimeStep[0]));
            });

            //_mapperConfiguration.AssertConfigurationIsValid();
        }

        public static TDestination Map<TSource, TDestination>(TSource obj)
        {
            return _mapperConfiguration.CreateMapper().Map<TDestination>(obj);
        }
    }
}