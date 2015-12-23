using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class TestContextTests
    {
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                if(TestContext.CurrentContext.Result.Outcome.Label == "Error")
                    Console.WriteLine("Test is in Error");
                else
                    Console.WriteLine("Test Failed");
            }
        }

        [Test]
        public void PassingMethod()
        {
            Assert.Pass("Your first passing test");
        }

        [Test]
        [Explicit("Failing test for testing")]
        public void FailingMethod()
        {
            Assert.Fail("This test fails");
        }

        [Test]
        [Explicit("Error test for testing")]
        public void ErrorMethod()
        {
            throw new ArgumentException();
        }
    }
}
