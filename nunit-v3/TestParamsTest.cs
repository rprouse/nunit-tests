using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class TestParamsTest
    {
        [Test]
        public void TestCommandLineParameters()
        {
            var code = TestContext.Parameters.Get("Code", "<unknown>");
            var date = TestContext.Parameters.Get("Date", DateTime.MinValue);

            TestContext.WriteLine($"Fetched test parameters {code} and {date}");
        }
    }

    [TestFixtureSource(nameof(TestData))]
    public class TestParamsInSource
    {
        private readonly string _param;

        public TestParamsInSource(string param)
        {
            _param = param;
        }

        [Test]
        [Explicit("Only run with parameters")]
        public void TestParameter()
        {
            TestContext.WriteLine($"Parameter: {_param}");
            Assert.That(_param, Is.Not.EqualTo("<unknown>"));
        }

        public static IEnumerable<string> TestData()
        {
            yield return TestContext.Parameters.Get("Param", "<unknown>");
        }
    }
}
