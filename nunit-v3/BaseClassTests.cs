using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    public class LoggingBase
    {
        [TearDown]
        public void LogResults()
        {
            TestContext.WriteLine($"{TestContext.CurrentContext.Test.Name}: {TestContext.CurrentContext.Result.Outcome}");
        }
    }

    [TestFixture]
    public class DerivedClassTests : LoggingBase
    {
        [SetUp]
        public void SetUp()
        {
            TestContext.WriteLine("SetUp");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("SetUp");
        }

        [Test]
        public void TestMethod()
        {
            Assert.Pass(nameof(DerivedClassTests));
        }
    }
}
