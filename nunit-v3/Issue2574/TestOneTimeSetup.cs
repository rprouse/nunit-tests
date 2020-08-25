using System.Runtime.Serialization;
using NUnit.Framework;

namespace nunit.v3.Issue2574
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class TestOneTimeSetup
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        int oneTimeSetupCount = 0;
        int oneTimeTeardownCount = 0;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            OutputReferenceId("OneTimeSetUp");
            oneTimeSetupCount++;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OutputReferenceId("OneTimeTearDown");
            oneTimeTeardownCount++;
        }

        [Test]
        public void TestOne()
        {
            OutputReferenceId("TestOne");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        [Test]
        public void TestTwo()
        {
            OutputReferenceId("TestTwo");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        [Test]
        public void TestThree()
        {
            OutputReferenceId("TestThree");
            Assert.That(oneTimeSetupCount, Is.EqualTo(1));
            Assert.That(oneTimeTeardownCount, Is.EqualTo(0));
        }

        private void OutputReferenceId(string location)
        {
            long id = generator.GetId(this, out bool first);
            TestContext.WriteLine($"{location}: {id}");
        }
    }
}
