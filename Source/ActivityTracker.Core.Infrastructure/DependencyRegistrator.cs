using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace ActivityTracker.Core.Infrastructure
{
    public static class DependencyRegistrator
    {
        private static readonly IContainer _container;

        static DependencyRegistrator()
        {
            _container = new Container();

            LoadDependenciesOnce();
        }

        private static void LoadDependenciesOnce()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("ActivityTracker.")).ToList();

            foreach (var trackerAppAssembly in loadedAssemblies)
            {
                var interfaceToCheck = typeof(IDoDependencyRegistration);
                var doRegistrationTypes =
                    trackerAppAssembly.GetTypes().Where(type => interfaceToCheck.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToList();

                foreach (var doRegistrationType in doRegistrationTypes)
                {
                    var registrator = Activator.CreateInstance(doRegistrationType);
                    ((IDoDependencyRegistration)registrator).Register();
                }
            }
        }

        public static void Register<TMarker, TInstance>()
        {
            var registry = new Registry();
            registry.For(typeof(TMarker)).Use(typeof(TInstance));

            _container.Configure(cfg => cfg.AddRegistry(registry));
        }

        public static T Resolve<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
