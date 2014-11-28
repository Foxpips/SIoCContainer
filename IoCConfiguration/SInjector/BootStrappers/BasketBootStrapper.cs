using System;

using IoCConfiguration.SInjector.Registries;

using IoCContainer.BootStrappers;
using IoCContainer.Infrastructure;

namespace IoCConfiguration.SInjector.BootStrappers
{
    public class BasketBootStrapper : BootStrapper, IRunAtStartup
    {
        public void Configure()
        {
            ConfigureContainer(cfg => cfg.AddRegistry(new BasketRegistry()));
        }

        public void ExecuteOnStartup()
        {
            Configure();
        }

        public void ExecuteOnStartup(object sender, AssemblyLoadEventArgs args)
        {
            ExecuteOnStartup();
        }

        public void ExecuteOnShutdown()
        {
        }

        public void ExecuteOnShutdown(object sender, AssemblyLoadEventArgs args)
        {
        }
    }
}