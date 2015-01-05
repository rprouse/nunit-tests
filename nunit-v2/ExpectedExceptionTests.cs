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
        }

        private void MethodThatThrows()
        {
            throw new ArgumentException();
        }
    }
}
