using IoCContainer.Registers;

using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Customer;
using Shop.Domain.Entities.Proof;

namespace IoCConfiguration.SInjector.Registries
{
    public class CustomerRegistery : BaseRegistry
    {
        public CustomerRegistery()
        {
            Scan(scan =>
            {
                scan.From<ICustomer>().To<BillPayCustomer>();
                scan.From<IAddress>().To<BillingAddress>();
                scan.From<IProof>().To<Proof>();
                scan.From<IProofType>().To<ProofType>();
            });
        }
    }
}