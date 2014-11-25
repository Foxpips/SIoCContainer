using Shop.Domain.Entities.Cards;

using StructureMap.Configuration.DSL;

namespace StructureMapPlayground.Registries
{
    public class BasketRegistry : Registry
    {
        public BasketRegistry()
        {
            Scan(scan => For<ICreditCard>().Use<VisaDebit>());
        }
    }
}