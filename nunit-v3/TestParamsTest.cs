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
}
