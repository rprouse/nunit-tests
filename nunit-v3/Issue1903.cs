using System;
using NUnit.Framework;
using System.Collections;

namespace nunit.v3
{
    [TestFixture]
    public class Issue1903
    {
        [TestCaseSource(nameof(TestData))]
        public void TestExpectedLambda(int x, Func<int, bool> expected)
        {
            Assert.That(expected(x), Is.True);
        }

        static IEnumerable TestData()
        {
            yield return new TestCaseData(10, new Func<int, bool>(x => x > 5));
            yield return new TestCaseData(2, new Func<int, bool>(x => x < 3));
        }
    }
}
