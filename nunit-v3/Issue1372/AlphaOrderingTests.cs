using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3.Issue1372
{
    [TestFixture]
    public class AlphaOrderingTests
    {
        [Test]
        public void A_Test()
        {
            TestContext.WriteLine("A");
        }

        [Test]
        public void D_Test()
        {
            TestContext.WriteLine("D");
        }

        [Test]
        [Order(2)]
        public void E_Test()
        {
            TestContext.WriteLine("E");
        }

        [Test]
        public void B_Test()
        {
            TestContext.WriteLine("B");
        }

        [Test]
        public void C_Test()
        {
            TestContext.WriteLine("C");
        }

        [Test]
        [Order(1)]
        public void F_Test()
        {
            TestContext.WriteLine("F");
        }
    }
}
