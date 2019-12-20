using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class CodeLensTestWithTestCase
    {
        [Test]
        public void StraightCodeLensTest()
        {
            Assert.Pass("This works");
        }

        [TestCase(2, 2, 4)]
        [TestCase(8, 2, 10)]
        [TestCase(1, 2, 3)]
        public void TestCasesWithCodeLensTest(int x, int y, int expected)
        {
            Assert.That(x + y, Is.EqualTo(expected));
        }
    }
}
