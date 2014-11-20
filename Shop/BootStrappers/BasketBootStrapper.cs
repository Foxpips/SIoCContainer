using System;

using Shop.Registries;

using SIoCContainer.BootStrappers;
using SIoCContainer.Infrastructure;

namespace Shop.BootStrappers
{
    public class BasketBootStrapper : BootStrapper, IRunAtStartup
    {
        public void Configure()
        {
            ConfigureContainer(cfg => cfg.AddRegistry(new BasketRegistry()));
        }

        public void ExecuteOnStartup(object sender, AssemblyLoadEventArgs args)
        {
            Configure();
        }

        public void ExecuteOnShutdown(object sender, AssemblyLoadEventArgs args)
        {
        }
    }
}