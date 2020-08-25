using System.Runtime.Serialization;
using NUnit.Framework;

namespace nunit.v3.Issue2574
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class TestInstancePerFixture
    {
        static ObjectIDGenerator generator = new ObjectIDGenerator();
        static long lastObjectId = 0;
        int _count = 0;

        [Test]
        public void TestOne()
        {
            _count++;
            Assert.That(_count, Is.EqualTo(1));

            long id = generator.GetId(this, out bool first);
            Assert.That(first, Is.True);
            Assert.That(id, Is.Not.EqualTo(lastObjectId));
            lastObjectId = id;
        }

        [Test]
        public void TestTwo()
        {
            _count++;
            Assert.That(_count, Is.EqualTo(1));

            long id = generator.GetId(this, out bool first);
            Assert.That(first, Is.True);
            Assert.That(id, Is.Not.EqualTo(lastObjectId));
            lastObjectId = id;
        }

        [Test]
        public void TestThree()
        {
            _count++;
            Assert.That(_count, Is.EqualTo(1));

            long id = generator.GetId(this, out bool first);
            Assert.That(first, Is.True);
            Assert.That(id, Is.Not.EqualTo(lastObjectId));
            lastObjectId = id;
        }

        [Test]
        [Repeat(10)]
        public void TestRepeat()
        {
            _count++;
            Assert.That(_count, Is.EqualTo(1));

            long id = generator.GetId(this, out bool first);
            Assert.That(first, Is.True);
            Assert.That(id, Is.Not.EqualTo(lastObjectId));
            lastObjectId = id;
        }
    }
}
