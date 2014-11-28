using System;
using System.Linq;

using IoCConfiguration.SInjector.BootStrappers;

using IoCContainer.Infrastructure;
using IoCContainer.Injectors;

using NUnit.Framework;

using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

namespace IoCContainerTests.Tests
{
    public class InjectorTests
    {
        [SetUp]
        public void SetUp()
        {
            Type[] exportedTypes = typeof (BasketBootStrapper).Assembly.GetExportedTypes();

            foreach (var exportedType in exportedTypes)
            {
                if (typeof (IRunAtStartup).IsAssignableFrom(exportedType) && exportedType.GetInterfaces().Any())
                {
                    ((IRunAtStartup) Activator.CreateInstance(exportedType)).ExecuteOnStartup();
                }
            }
        }

        [Test]
        public void SkeetInjector_TestedBehavior_ExpectedResult()
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

        [Test]
        public void SonMezjector_TestedBehavior_ExpectedResult()
        {
            var injector = new SonmezInjector();

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

        [Test]
        public void SInjector_TestedBehavior_ExpectedResult()
        {
            var injector = new SInjector();

            var resolve = injector.Resolve<ProofOrder>();

            const string hey = "Test";
            var description = ((ProofType) ((Proof) resolve.Proof).CustomerProof).Description = hey;

            Assert.That(description, Is.Not.Null);
            Assert.That(description, Is.EqualTo(hey));
            Assert.That(resolve.Card.Charge(), Is.Not.Null.Or.Empty);
        }
    }
}