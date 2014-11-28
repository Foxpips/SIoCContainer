using IoCContainer.Registers;

namespace IoCContainer.BootStrappers
{
    public class Configurator
    {
        public void AddRegistry(IRegistry dependencyRegistry)
        {
            foreach (var registeredType in dependencyRegistry.GetRegisteredTypes())
            {
                IoCCoreRegister.Register(registeredType.Key, registeredType.Value);
            }
        }
    }
}