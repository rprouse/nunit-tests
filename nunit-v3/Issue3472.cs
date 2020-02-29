using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class Issue3472
    {
        [TestCase(@"ÑÐ")]
        public void Test_ND(string name)
        {
            Assert.Pass(name);
        }
    }
}
