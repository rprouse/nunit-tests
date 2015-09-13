using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace nunit.v2
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        public void ThrowsException()
        {
            Assert.Throws<ArgumentException>( MethodThatThrows );
            Assert.That( MethodThatThrows, Throws.ArgumentException.With.Message.EqualTo("Test") );
        }

        private void MethodThatThrows()
        {
            throw new ArgumentException("Test");
        }

        [TestCase(1)]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        public void TestThrows( int x )
        {
            MustBeGreaterThanZero( x );
        }

        private void MustBeGreaterThanZero( int x )
        {
            if(x <= 0) throw new ArgumentException("Must be greater than 0", "x");
        }
    }
}
