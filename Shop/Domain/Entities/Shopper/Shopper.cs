using System;

using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Customer;

namespace Shop.Domain.Entities.Shopper
{
    public class Shopper
    {
        private ICreditCard _card;
        private ICustomer _customerType;

        public Shopper()
        {
        }

        public Shopper(ICustomer billPayCustomer)
        {
            _customerType = billPayCustomer;
        }

        public Shopper(ICreditCard card)
        {
            _card = card;
        }

        public string ShopName { get; set; }

        public IAddress Address { get; set; }

        public Shopper Inject(ICreditCard card)
        {
            _card = card;
            return this;
        }

        public void Charge()
        {
            var chargeMessage = _card.Charge();
            Console.WriteLine(chargeMessage);
        }
    }
}