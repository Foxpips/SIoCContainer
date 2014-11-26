using NUnit.Framework;

using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using StructureMapPlayground.BootStrappers;

namespace SIoCContainerTests.Tests
{
    public class StructureMapTests
    {
        [Test]
        public void MethodUnderTest_TestedBehavior_ExpectedResult()
        {
            var container = new BasketBootStrapper().CreateContainer();
            var creditCard = container.GetInstance<VisaDebit>();

            Assert.That(creditCard.Charge(), Is.Not.Null.Or.Empty);
        }

        [Test]
        public void TestOrder_StructureMap_InjectsDependencies()
        {
            const string expected = "test";
            var container = new OrderBootStrapper().CreateContainer();
            var instance = container.GetInstance<ProofOrder>();
            var description = ((ProofType) ((Proof) instance.Proof).CustomerProof).Description = expected;

            Assert.That(description, Is.Not.Null.Or.Empty);
            Assert.That(description, Is.EqualTo(expected));
            Assert.That(instance.Card.Charge(), Is.Not.Null.Or.Empty);
        }
    }
}