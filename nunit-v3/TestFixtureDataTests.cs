using System.Collections.Generic;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixtureSource(typeof(TestDataProvider), nameof(TestDataProvider.InjectionData))]
    public class TestFixtureDataTests
    {
        string _injected;

        public TestFixtureDataTests(string injected)
        {
            _injected = injected;
        }

        [Test]
        public void TestInjected()
        {
            Assert.That(_injected, Is.Not.Null.Or.Empty);
        }
    }

    public static class TestDataProvider
    {
        public static IEnumerable<TestFixtureData> InjectionData =>
            new[]
            {
                new TestFixtureData("One"),
                new TestFixtureData("Two"),
            };
    }
}
