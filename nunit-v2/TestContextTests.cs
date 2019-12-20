using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nunit.v2
{
    [TestFixture]
    [Category("Fixture")]
    public class TestContextTests
    {
        [SetUp]
        public void SetUp()
        {
            var properties = TestContext.CurrentContext.Test.Properties;
        }

        [Test]
        [Category("Test")]
        public void PassingMethod()
        {
            Assert.Pass("Your first passing test");
        }
    }
}
