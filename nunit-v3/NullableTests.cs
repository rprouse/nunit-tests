using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class NullableTests
    {
        [Test]
        public void TestNullableBooleanTrue()
        {
            bool? b = true;
            Assert.That(b, Is.True);
        }

        [Test]
        public void TestNullableBooleanFalse()
        {
            bool? b = false;
            Assert.That(b, Is.False);
        }

        [Test]
        public void TestNullableBooleanNull()
        {
            bool? b = null;
            Assert.That(b, Is.Null);
        }
    }
}
