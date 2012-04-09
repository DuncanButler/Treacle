using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Treacle.Tests
{
    public abstract class BaseTest
    {
        public void Describes(string description)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(description);
            Console.WriteLine("--------------------------------------");
        }

        public void IsPending()
        {
            Console.WriteLine(" {0} -- PENDING", GetCaller());

            Assert.Inconclusive();
        }

        [SetUp]
        public void Init()
        {
            EstablishContext();
            BecauseOf();
        }

        protected virtual void EstablishContext()
        {            
        }

        protected virtual void BecauseOf()
        {
        }

        string GetCaller()
        {
            var stack = new StackTrace();

            return stack.GetFrame(2).GetMethod().Name.Replace("_", " ");
        }
    }

    public static class BddAssertions
    {
         public static void IsEqualTo<T>(this T actual, T expected)
         {
             Assert.That(actual,Is.EqualTo(expected));
         }

         public static void IsGreaterThan<T>(this T actual, T expected)
         {
             Assert.That(actual,Is.GreaterThan(expected));
         }
    }
}