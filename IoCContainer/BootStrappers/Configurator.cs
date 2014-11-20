using SIoCContainer.Registers;
using SIoCContainer.Resolver;

namespace SIoCContainer.BootStrappers
{
    public class Configurator
    {
        public void AddRegistry(IRegistry dependencyRegistry)
        {
            foreach (var registeredType in dependencyRegistry.GetRegisteredTypes())
            {
                DependencyResolver.Register(registeredType.Key, registeredType.Value);
            }
        }
    }
}