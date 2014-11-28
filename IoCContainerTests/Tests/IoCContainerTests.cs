using System.Reflection;

using IoCConfiguration.SInjector.BootStrappers;

using NUnit.Framework;

using Shop.Domain.Entities.Address;
using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using SIoCContainer.Resolver;
using SIoCContainer.Services;

namespace SIoCContainerTests.Tests
{
    public class IoCContainerTests
    {
        [Test]
        [Ignore("Dependency Resolver is being phased out")]
        public void TestDependencyResolver_Customer_InjectsRequiredObjects()
        {
            new BasketBootStrapper().Configure();
            var basket = DependencyResolver.Resolve<Basket>();

            Assert.That(basket.Card.GetType(), Is.EqualTo(typeof (VisaDebit)));
            ObjectCrawlerService.IterateTypeMemberValues(basket);
        }

        [Test]
        [Ignore("Dependency Resolver is being phased out")]
        public void MethodUnderTest_TestedBehavior_ExpectedResult()
        {
            new CustomerBootStrapper().Configure();
            var order = DependencyResolver.Resolve<Order>();

            var fieldInfo = order.GetType().GetField("_address",
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);

            if (fieldInfo != null)
            {
                var addressType =
                    fieldInfo.GetValue(order);
                Assert.That(addressType.GetType(), Is.EqualTo(typeof (BillingAddress)));
            }

            Assert.That(order.GetCustomerMonthlyBalance(), Is.GreaterThan(0));
            Assert.That(order.CustomerProof.GetType(), Is.EqualTo(typeof (Proof)));
            Assert.That(order.CreditCard.GetType(), Is.EqualTo(typeof (VisaDebit)));

            ObjectCrawlerService.IterateTypeMemberValues(order);
        }
    }
}