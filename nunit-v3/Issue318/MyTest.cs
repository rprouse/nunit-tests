using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace nunit.v3.Issue318
{
    public class OnTestFixtureAttribute : TestActionAttribute
    {
        public override void BeforeTest(ITest test)
        {
            Assert.That(test, Is.Not.Null);
            Assert.That(test.Fixture, Is.Not.Null);
            Assert.That(test.Fixture.GetType(), Is.EqualTo(test.FixtureType));
        }
    }

    public class OnTestMethodAttribute : TestActionAttribute
    {
        public override void BeforeTest(ITest test)
        {
            Assert.That(test, Is.Not.Null);
            Assert.That(test.Fixture, Is.Not.Null);
            Assert.That(test.Fixture.GetType(), Is.EqualTo(test.FixtureType));
        }
    }

    [OnTestFixture]
    [TestFixture]
    public class FixtureIsNotNullForTests
    {
        [OnTestMethod]
        [Test]
        public void TestMethod()
        {
        }
    }
}
