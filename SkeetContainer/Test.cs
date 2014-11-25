using System;
using System.Globalization;

using NUnit.Framework;

using Shop.Domain.Entities.Cards;
using Shop.Domain.Entities.Proof;
using Shop.Domain.Entities.Shop;

using SIoCContainer.Resolver;

namespace SkeetContainer
{
    public class Test
    {
        [Test]
        public void MethodUnderTest_TestedBehavior_ExpectedResult()
        {
            var injector = new Injector();

            injector.Bind<IClock, Clock>();
            injector.Bind<IDate, Date>();

            var resolve = injector.Resolve<Diary>();
            resolve.Clock.PrintInstance();
            ((Clock) resolve.Clock)._date.PrintDate();
        }

        [Test]
        public void Tests_TestedBehavior_ExpectedResult()
        {
            var resolver = new Resolver();

            resolver.Register<IClock, Clock>();
            resolver.Register<Diary, Diary>();
            var resolve = resolver.Resolve<Diary>();
            resolve.Clock.PrintInstance();
        }

        [Test]
        public void Test_TestedBehavior_ExpectedResult()
        {
            var injector = new SkeetInjector();

            injector.Bind<IClock, Clock>();
            injector.Bind<IDate, Date>();

            var resolve = injector.Resolve<Diary>();
            resolve.Clock.PrintInstance();
            ((Clock) resolve.Clock)._date.PrintDate();
        }

        [Test]
        public void TestOrder2_TestedBehavior_ExpectedResult()
        {
            var injector = new SkeetInjector();

            injector.Bind<IProof, Proof>();
            injector.Bind<ICreditCard, VisaDebit>();
            injector.Bind<IProofType, ProofType>();

            var resolve = injector.Resolve<Order2>();

            string description = ((ProofType) ((Proof) resolve.Proof).CustomerProof).Description = "Hey";

            Console.WriteLine(description);

            resolve.Card.Charge();
        }
    }

    public class Diary : IDiary
    {
        public IClock Clock { get; set; }

        public Diary(IClock clock)
        {
            Clock = clock;
        }
    }

    public interface IDiary
    {
    }

    public class Clock : IClock
    {
        public DateTime Instance
        {
            get { return DateTime.Now; }
        }

        public readonly Date _date;

        public void PrintInstance()
        {
            Console.WriteLine(Instance);
        }

        public Clock(Date date)
        {
            _date = date;
        }
    }

    public class Date : IDate
    {
        public void PrintDate()
        {
            Console.WriteLine("The Date is: " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }
    }

    public interface IDate
    {
        void PrintDate();
    }

    public interface IClock
    {
        void PrintInstance();
    }
}