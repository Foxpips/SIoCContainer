using IoCConfiguration.StructureMap.Registries;

using StructureMap;

namespace IoCConfiguration.StructureMap.BootStrappers
{
    public class OrderIsmBootStrapper : ISmBootStrapper
    {
        public Container CreateContainer()
        {
            var container = new Container();
            container.Configure(cfg =>
            {
                cfg.AddRegistry(new BasketRegistry());
                cfg.AddRegistry(new OrderRegistry());
            });

            return container;
        }
    }
}