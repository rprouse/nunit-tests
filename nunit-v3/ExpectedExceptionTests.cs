using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace nunit.v3
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        public void ThrowsException()
        {
            Assert.Throws<ArgumentException>(MethodThatThrows);
            Assert.That(MethodThatThrows, Throws.ArgumentException);
        }

    [Test]
    public void DoesNotThrowSpecificException()
    {
        try
        {
            MethodThatThrows();
        }
        catch (Exception ex)
        {
            Assert.That(ex, Is.Not.TypeOf(typeof(Exception)));
        }
    }

        private void MethodThatThrows()
        {
            throw new ArgumentException();
        }

        [TestCase(1)]
        public void TestThrows(int x)
        {
            MustBeGreaterThanZero(x);
        }

        private void MustBeGreaterThanZero(int x)
        {
            if (x <= 0) throw new ArgumentException("Must be greater than 0", "x");
        }


        [Test]
        public void RunTest()
        {
            Assert.That(() => RetMethod(), Throws.InstanceOf<Exception>());
        }

        private static sbyte RetMethod()
        {
            throw new Exception();
        }

        [TestCase("27/04/2025", "Holiday cannot start or end on a weekend or non-working day")]
        public void AddHolidays_Exceptions(string date, string expectedMessage)
        {
            Assert.That(() => ParseDate(date), Throws.ArgumentException.With.Message.EqualTo(expectedMessage));
        }

        void ParseDate(string date)
        {
            throw new ArgumentException("Holiday cannot start or end on a weekend or non-working day");
        }

        [Test]
        public void Test_Exception()
        {
            Assert.That(() => { throw new Exception("KAPOW"); }, Throws.Exception);
        }

        [Test]
        public void Test_Blocking()
        {
            Assert.That(() => { Thread.Sleep(100); throw new Exception("KAPOW"); }, Throws.Exception);
        }

        //[Test]
        //public async Task Test_Async_1()
        //{
        //    Assert.That(async () => { await Task.Delay(100); throw new Exception("KAPOW"); }, Throws.Exception);
        //}

        [Test]
        public void Test_Async_4()
        {
            Assert.That(async () => { await Task.Delay(100); throw new ArgumentException("KAPOW"); }, Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Async_3()
        {
            Assert.That(async () => { await Task.Delay(100); throw new Exception("KAPOW"); }, Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Async_2()
        {
            Assert.That(async () => { await Task.Delay(100); throw new Exception("KAPOW"); }, Throws.Exception.TypeOf(typeof(Exception)));
        }
    }
}
