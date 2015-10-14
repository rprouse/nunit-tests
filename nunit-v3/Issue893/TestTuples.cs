using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3.Issue893
{
    [TestFixture]
    public class TestTuples
    {
        [Test]
        [Ignore("Needs to be fixed for issue 893")]
        public void TupleIntVsDouble()
        {
            Tuple<int, int> actual = Tuple.Create(1, 2);
            Tuple<double, double> expected = Tuple.Create(1.0, 2.0);
            
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
