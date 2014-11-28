using IoCConfiguration.StructureMap.Registries;

using StructureMap;

namespace IoCConfiguration.StructureMap.BootStrappers
{
    public class SmBasketIsmBootStrapper : ISmBootStrapper
    {
        public Container CreateContainer()
        {
            return new Container(new BasketRegistry());
        }
    }
}