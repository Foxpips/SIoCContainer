using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Customer;
using Shop.Domain.Entities.Shopper;

using SIoCContainer.Services;

namespace SIoCContainerTests.Tests
{
    public class ManualDependencyInjectionTests
    {
        [Test]
        public void DependcyInjection_ConstructorInjection_InjectICustomerType()
        {
            var shopper = new Shopper(new BillPayCustomer());
            Assert.That(shopper._customerType.GetType(), Is.EqualTo(typeof(BillPayCustomer)));
        }

        [Test]
        public void DependencyInjection_SetterInjection_InjectIAddress()
        {
            var shopper = new Shopper {Address = new BillingAddress()};
            Assert.That(shopper.Address.GetType(), Is.EqualTo(typeof (BillingAddress)));
        }

        [Test]
        public void DependencyInjection_InterfaceInjection_InjectIPaymentMethod()
        {
            var shopper = new Shopper();
            shopper.Inject(new VisaDebit());
            Assert.That(shopper._card.GetType(), Is.EqualTo(typeof(VisaDebit)));
        }

        [Test]
        public void PerformAllInjections_OnShopperClass_AllInjectionsSuccessful()
        {
            //All 3 Injections at once
            var shopper = new Shopper(new BillPayCustomer())
            {
                Address = new BillingAddress()
            }.Inject(new VisaDebit());

            var reflectedObjects = ClassCrawlerService.GetAllMemberInfos(shopper,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            var objects = reflectedObjects as IList<ClassCrawlerService.ReflectedObject> ??
                          reflectedObjects.ToList();

            Assert.IsTrue(ClassCrawlerService.DoesClassContainType<BillPayCustomer>(objects));
            Assert.IsTrue(ClassCrawlerService.DoesClassContainType<BillingAddress>(objects));
            Assert.IsTrue(ClassCrawlerService.DoesClassContainType<VisaDebit>(objects));
        }
    }
}