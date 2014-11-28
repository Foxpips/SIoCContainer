using System;

namespace IoCContainer.BootStrappers
{
    public class BootStrapper : IBootStrapper
    {
        public void ConfigureContainer(Action<Configurator> action)
        {
            action(new Configurator());
        }
    }
}