using System;

using NUnit.Framework;

namespace CSharpDesign
{
    public abstract class Person : IPerson
    {
        public virtual void GetJob()
        {
            Console.WriteLine("Works as a barman");
        }
    }

    public class Spy : Person
    {
        public override void GetJob()
        {
            Console.WriteLine("Is a spy barman");
        }
    }

    public interface IPerson
    {
        void GetJob();
    }

    public class TestInheritance
    {
        [Test]
        public void MethodUnderTest_TestedBehavior_ExpectedResult()
        {
            var spy = new Spy();
            spy.GetJob();
        }
    }
}