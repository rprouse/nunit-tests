using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class IgnoreTests
    {
        [Ignore("NUnit Issue #1762")]
        [Test]
        public void IgnoreBeforeTest()
        {
            Assert.Fail("This test should be ignored");
        }

        [Test]
        [Ignore("NUnit Issue #1762")]
        public void IgnoreAfterTest()
        {
            Assert.Fail("This test should be ignored");
        }

        [Ignore("NUnit Issue #1762")]
        [TestCase(1)]
        [TestCase(2)]
        public void IgnoreBeforeTestCase(int i)
        {
            Assert.Fail("This test should be ignored");
        }

        [TestCase(1)]
        [TestCase(2)]
        [Ignore("NUnit Issue #1762")]
        public void IgnoreAfterTestCase(int i)
        {
            Assert.Fail("This test should be ignored");
        }
    }
}
