using StructureMap;

using StructureMapPlayground.Registries;

namespace StructureMapPlayground.BootStrappers
{
    public class BasketResolver
    {
        public Container Resolve()
        {
            return new Container(new BasketRegistry());
        }
    }
}