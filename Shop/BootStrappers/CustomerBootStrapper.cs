using System;
using System.Text;

using Shop.Registries;

using SIoCContainer.BootStrappers;
using SIoCContainer.Infrastructure;

namespace Shop.BootStrappers
{
    public class CustomerBootStrapper : BootStrapper, IRunAtStartup
    {
        public void Configure()
        {
            ConfigureContainer(cfg => cfg.AddRegistry(new CustomerRegistery()));
        }

        public void ExecuteOnStartup(object sender, AssemblyLoadEventArgs args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Configure();
        }

        public void ExecuteOnShutdown(object sender, AssemblyLoadEventArgs args)
        {
        }
    }
}