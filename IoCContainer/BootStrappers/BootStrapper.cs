using System;

namespace SIoCContainer.BootStrappers
{
    public class BootStrapper : IBootStrapper
    {
        public void ConfigureContainer(Action<Configurator> action)
        {
            action(new Configurator());
        }
    }
}