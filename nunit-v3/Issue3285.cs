using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class Issue3285
    {
        [Test]
        public void TestValuesAttribute([Values(1, 2, 3)] int x)
        {
            Assert.That(x, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void TestValueSourceAttribute([ValueSource(nameof(Values))] int x)
        {
            Assert.That(x, Is.LessThanOrEqualTo(10));
        }

        public static IEnumerable<int> Values()
        {
            return Enumerable.Range(0, 10);
        }

        [TestCaseSource(nameof(Source))]
        public void TestTestCaseSource(int x)
        {
            Assert.That(x, Is.LessThanOrEqualTo(10));
        }

        public static IEnumerable<TestCaseData> Source()
        {
            yield return new TestCaseData(1).SetName("TestOne");
            yield return new TestCaseData(2).SetName("TestTwo");
            yield return new TestCaseData(3).SetName("TestThree");
        }
    }
}
