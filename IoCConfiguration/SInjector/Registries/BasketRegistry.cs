using IoCContainer.Registers;

using Shop.Domain.Entities.Cards;

namespace IoCConfiguration.SInjector.Registries
{
    public class BasketRegistry : BaseRegistry
    {
        public BasketRegistry()
        {
            Scan(scan => scan.AssemblyContainingType<VisaDebit>());
        }
    }
}