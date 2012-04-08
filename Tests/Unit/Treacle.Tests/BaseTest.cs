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
}