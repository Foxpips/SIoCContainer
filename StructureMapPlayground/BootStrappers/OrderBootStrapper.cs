using StructureMap;

using StructureMapPlayground.Registries;

namespace StructureMapPlayground.BootStrappers
{
    public class OrderBootStrapper : IBootStrapper
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