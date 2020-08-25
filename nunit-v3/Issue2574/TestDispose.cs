using System;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace nunit.v3.Issue2574
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class TestDispose : IDisposable
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        static int disposeCount = 0;

        [Test]
        [Order(1)]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(disposeCount, Is.EqualTo(0));
        }

        [Test]
        [Order(2)]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(disposeCount, Is.EqualTo(1));
        }

        [Test]
        [Order(3)]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(disposeCount, Is.EqualTo(2));
        }

        public void Dispose()
        {
            OutputReferenceId("Dispose");
            disposeCount++;
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id}");
        }
    }
}
