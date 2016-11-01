using NUnit.Framework;
using System;

namespace nunit.v3
{
    [Ignore("These are failing tests")]
    public class FailingTest
    {
        [Test]
        public void WatchMeFail()
        {
            Assert.Fail("Watch me fail!");
        }

        [Test]
        public void WatchMeThrowAnException()
        {
            throw new NotImplementedException("Watch me crash and burn!");
        }

        [Test]
        public void TestSuperHero()
        {
            var obj = new SuperHero();
            obj.Batman();
            Assert.Pass();
        }
    }

    public class SuperHero
    {
        public void Batman()
        {
            throw new Exception("Batman failed");
        }
    }
}
