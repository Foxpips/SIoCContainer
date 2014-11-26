using NUnit.Framework;

using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using SIoCContainer.Injectors;

namespace SIoCContainerTests.Tests
{
    public class InjectorTests
    {
        [Test]
        public void TestOrder2_TestedBehavior_ExpectedResult()
        {
            var injector = new SkeetInjector();

            injector.Bind<IProof, Proof>();
            injector.Bind<ICreditCard, VisaDebit>();
            injector.Bind<IProofType, ProofType>();

            var resolve = injector.Resolve<ProofOrder>();

            const string hey = "Test";
            var description = ((ProofType) ((Proof) resolve.Proof).CustomerProof).Description = hey;

            Assert.That(description, Is.Not.Null);
            Assert.That(description, Is.EqualTo(hey));
            Assert.That(resolve.Card.Charge(), Is.Not.Null.Or.Empty);
        }
    }
}