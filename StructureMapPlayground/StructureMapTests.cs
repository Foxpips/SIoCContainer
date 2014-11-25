using System;

using NUnit.Framework;

using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using StructureMap;

using StructureMapPlayground.Registries;

namespace StructureMapPlayground
{
    public class StructureMapTests
    {
        [Test]
        public void MethodUnderTest_TestedBehavior_ExpectedResult()
        {
            var container = new Container(new BasketRegistry());

            var creditCard = container.GetInstance<ICreditCard>();

            Console.WriteLine(creditCard.Charge());
        }

        [Test]
        public void TestOrder_StructureMap_InjectsDependencies()
        {
            var container = new Container();
            container.Configure(cfg =>
            {
                cfg.AddRegistry(new BasketRegistry());
                cfg.AddRegistry(new OrderRegistry());
            });

            var instance = container.GetInstance<Order2>();
            var description = ((ProofType) ((Proof) instance.Proof).CustomerProof).Description = "hello";
            Console.WriteLine(description);
            Console.WriteLine(instance.Card.Charge());
            
        }
    }
}