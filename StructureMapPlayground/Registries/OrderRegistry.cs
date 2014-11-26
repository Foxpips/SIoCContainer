using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using StructureMap.Configuration.DSL;

namespace StructureMapPlayground.Registries
{
    public class OrderRegistry : Registry
    {
        public OrderRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<ProofOrder>();
                scan.AssemblyContainingType<VisaDebit>();
                scan.AssemblyContainingType<Proof>();
                scan.WithDefaultConventions();
            });
        }
    }
}