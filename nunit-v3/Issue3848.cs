using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.All)]
    [TestFixtureSource(nameof(Issue3848.GetBrowsers))] //This gets Chrome and Edge test like below
    public class Issue3848
    {
        private static Random _random = new Random();
        private readonly string _browser;
        private readonly int _instanceId;

        public Issue3848(string browser)
        {
            _browser = browser;
            _instanceId = _random.Next(100);
        }

        [Test]
        public void Test1()
        {
            //Test Logic
            TestContext.WriteLine($"Test1 => Browser: {_browser}, Instance: {_instanceId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        [Test]
        public void Test2()
        {
            //Test Logic
            TestContext.WriteLine($"Test2 => Browser: {_browser}, Instance: {_instanceId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static IEnumerable<string> GetBrowsers => new[] { "Chrome", "Edge" };
    }
}
