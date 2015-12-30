using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        public void ThrowsException()
        {
            Assert.Throws<ArgumentException>( MethodThatThrows );
            Assert.That( MethodThatThrows, Throws.ArgumentException );
        }

        private void MethodThatThrows()
        {
            throw new ArgumentException();
        }

        [TestCase( 1 )]
        public void TestThrows( int x )
        {
            MustBeGreaterThanZero( x );
        }

        private void MustBeGreaterThanZero( int x )
        {
            if ( x <= 0 ) throw new ArgumentException( "Must be greater than 0", "x" );
        }


        [Test]
        public void RunTest()
        {
            Assert.That(RetMethod, Throws.Exception);
        }

        private static sbyte RetMethod()
        {
            throw new Exception();
        }
    }
}
