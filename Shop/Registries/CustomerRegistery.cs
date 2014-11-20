using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Customer;
using Shop.Domain.Entities.Proof;

using SIoCContainer.Registers;

namespace Shop.Registries
{
    public class CustomerRegistery : BaseRegistry
    {
        public CustomerRegistery()
        {
            Scan(scan =>
            {
                scan.From<ICreditCard>().To<VisaDebit>();
                scan.From<ICustomer>().To<BillPayCustomer>();
                scan.From<IAddress>().To<BillingAddress>();
                scan.From<IProof>().To<Proof>();
            });
        }
    }
}