using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;

namespace Shop.Domain.Entities.Shop
{
    public class ProofOrder : IOrder
    {
        public IProof Proof { get; set; }
        public ICreditCard Card { get; set; }

        public ProofOrder(IProof proof,ICreditCard card)
        {
            Proof = proof;
            Card = card;
        }
    }
}