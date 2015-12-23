using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class BaseClassTests
    {
        [Test]
        public virtual void TestMethod()
        {
            Assert.Pass(nameof(BaseClassTests));
        }
    }

    [TestFixture]
    public class DerivedClassTests : BaseClassTests
    {
        [Test]
        public override void TestMethod()
        {
            Assert.Pass(nameof(DerivedClassTests));
        }
    }
}
