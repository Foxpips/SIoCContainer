using Rhino.ServiceBus.StructureMap;

using StructureMap;

using StructureMapPlayground.Registries;

namespace StructureMapPlayground.BootStrappers
{
    public class OrderBootStrapper : StructureMapBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

             new Container().Configure(cfg =>
            {
                cfg.AddRegistry(new BasketRegistry());
                cfg.AddRegistry(new OrderRegistry());
            });
        }
    }
}