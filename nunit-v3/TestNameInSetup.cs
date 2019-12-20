using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class TestNameInSetup
    {
        [SetUp]
        public void SetUp()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            TestContext.WriteLine($"SetUp for {testName}");
        }

        [Test]
        public void NamedTest()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            TestContext.WriteLine($"Running test {testName}");
        }

        [Test]
        public void ExampleOfConsoleOutput()
        {
            Console.WriteLine("Console.WriteLine In ExampleOfConsoleOutput");
            TestContext.WriteLine("TestContext.WriteLine In ExampleOfConsoleOutput");
            TestContext.Progress.WriteLine("TestContext.Progress.WriteLine In ExampleOfConsoleOutput");
        }
    }
}
