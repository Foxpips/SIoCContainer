using StructureMap;

namespace StructureMapPlayground.BootStrappers
{
    public interface IBootStrapper
    {
        Container CreateContainer();
    }
}