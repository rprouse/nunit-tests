using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class Issue1062
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.WriteLine("OneTimeSetUp - TC");
            Console.WriteLine("OneTimeSetUp");
        }

        [SetUp]
        public void SetUp()
        {
            TestContext.WriteLine("SetUp - TC");
            Console.WriteLine("SetUp");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("TearDown - TC");
            Console.WriteLine("TearDown");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestContext.WriteLine("OneTimeTearDown - TC");
            Console.WriteLine("OneTimeTearDown");
        }

        [Test]
        public void Test()
        {
            TestContext.WriteLine("Test - TC");
            Console.WriteLine("Test");
        }
    }
}
