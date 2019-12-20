using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class StopTestRuns
    {
        bool _stopTests; // = true;

        [SetUp]
        public void SetUp()
        {
            Assume.That(_stopTests, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                _stopTests = true;
            }
        }

        [Test]
        public void TestOne()
        {
            Assert.Pass("This passed");
        }

        [Test]
        public void TestTwo()
        {
            //Assert.Fail("This failed too");
        }

        [Test]
        public void TestThree()
        {
            //Assert.Fail("This failed three");
        }
    }
}
