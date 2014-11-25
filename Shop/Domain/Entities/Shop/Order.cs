using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Customer;
using Shop.Domain.Entities.Proof;

using SIoCContainer.Attributes;

namespace Shop.Domain.Entities.Shop
{
    public class Order : IOrder
    {
        public Order(ICustomer customer, IAddress address)
        {
            Customer = customer;
            _address = address;
        }

        [Injectable("Simon")]
        public string Name { get; set; }

        [Injectable(1000)]
        public int OrderRef { get; set; }

        public ICreditCard CreditCard { get; set; }
        private ICustomer Customer { get; set; }
        public IProof CustomerProof { get; set; }
        private IAddress _address;
        public Basket Basket { get; set; }

        public int GetCustomerMonthlyBalance()
        {
            return Customer.GetCustomerBalance()/12;
        }
    }
}