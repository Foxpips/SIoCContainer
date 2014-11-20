using System;

namespace SIoCContainer.BootStrappers
{
    public interface IBootStrapper
    {
        void ConfigureContainer(Action<Configurator> config);
    }
}