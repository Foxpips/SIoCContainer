using Shop.Domain.Entities.Cards;

using SIoCContainer.Registers;

namespace Shop.Registries
{
    public class BasketRegistry : BaseRegistry
    {
        public BasketRegistry()
        {
            Scan(scan => scan.AssemblyContainingType<VisaDebit>());
        }
    }
}