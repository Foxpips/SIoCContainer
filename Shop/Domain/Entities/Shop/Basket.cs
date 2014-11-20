using System;

using Shop.Domain.Entities.Cards;

namespace Shop.Domain.Entities.Shop
{
    public class Basket
    {
        private readonly ICreditCard _card;
        public ICreditCard Card { get; set; }

        public Basket()
        {
        }

        public Basket(ICreditCard card)
        {
            Card = card;
        }

        public void Charge()
        {
            var chargeMessage = _card.Charge();
            Console.WriteLine(chargeMessage);
        }

        public void ChargeCard()
        {
            var chargeMessage = Card.Charge();
            Console.WriteLine(chargeMessage);
        }
    }
}