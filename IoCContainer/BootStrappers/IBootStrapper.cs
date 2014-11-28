using System;

namespace IoCContainer.BootStrappers
{
    public interface IBootStrapper
    {
        void ConfigureContainer(Action<Configurator> config);
    }
}