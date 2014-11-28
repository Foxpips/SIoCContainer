using StructureMap;

namespace IoCConfiguration.StructureMap
{
    public interface ISmBootStrapper
    {
        Container CreateContainer();
    }
}