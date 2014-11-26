using StructureMap;

using StructureMapPlayground.Registries;

namespace StructureMapPlayground.BootStrappers
{
    public class BasketBootStrapper : IBootStrapper
    {
        public Container CreateContainer()
        {
            return new Container(new BasketRegistry());
        }
    }
}