using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3.Issue2574
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class SetupTests
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        static int setupCount = 0;
        static int teardownCount = 0;

        [SetUp]
        public void SetUp()
        {
            OutputReferenceId("SetUp");
            setupCount++;
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            OutputReferenceId("TearDown");
            teardownCount++;
        }

        [Test]
        [Order(1)]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(setupCount, Is.EqualTo(1));
            Assert.That(teardownCount, Is.EqualTo(0));
        }

        [Test]
        [Order(2)]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(setupCount, Is.EqualTo(2));
            Assert.That(teardownCount, Is.EqualTo(1));
        }

        [Test]
        [Order(3)]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(setupCount, Is.EqualTo(3));
            Assert.That(teardownCount, Is.EqualTo(2));
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id}");
        }
    }
}
