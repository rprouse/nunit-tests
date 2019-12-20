using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    public class BaseClass1103
    {
        public static readonly object[] BaseTestCaseSource =
        {
             new TestCaseData("testCase")
        };
    }

    [TestFixture]
    public class ChildClass1103 : BaseClass1103
    {

        [TestCaseSource(typeof(BaseClass1103), "BaseTestCaseSource")]
        public void ChildTest(string argument)
        {
            Assert.That(argument, Is.Not.Null);
        }
    }
}
