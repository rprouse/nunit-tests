using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace nunit.v3
{
    [TestFixtureSource("TestData")]
    public class MultipleRunFixture
    {
        int _counter;

        public MultipleRunFixture(int counter)
        {
            _counter = counter;
        }

        public static IEnumerable<int> TestData =>
            Enumerable.Range(0, 100);

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass($"Test run {_counter}");
        }
    }
}
