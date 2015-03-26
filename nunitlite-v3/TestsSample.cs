using System;
using NUnit.Framework;

namespace NUnitLite.Tests
{
    [TestFixture]
    [Author( "Rob Prouse" )]
    public class TestsSample
    {
        [SetUp]
        public void Setup() { }


        [TearDown]
        public void Tear() { }

        [Test]
        [Category( "Passing" )]
        public void Pass()
        {
            TestContext.WriteLine( "Capture some output" );
            Assert.True( true );
        }

        [Test]
        [Category( "Failing" )]
        [Author( "Code Monkey" )]
        public void Fail()
        {
            Assert.False( true );
        }

        [Test]
        [Ignore( "another time" )]
        public void Ignore()
        {
            Assert.True( false );
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive( "Inconclusive" );
        }

        [Test]
        public void Error()
        {
            TestContext.WriteLine( "I am about to throw!!!" );
            throw new NotSupportedException( "This method isn't ready yet" );
        }
    }
}