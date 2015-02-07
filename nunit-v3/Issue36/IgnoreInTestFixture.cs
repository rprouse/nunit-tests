using NUnit.Framework;

namespace nunit.v3.Issue36
{
    [TestFixture]
    [Description("This is a test to see if the v2 Issue #36 occurs in v3, https://github.com/nunit/nunitv2/issues/36")]
    public class IgnoreInTestFixture
    {
        [Test]
        public void PassingButIgnoredTest()
        {
            Assert.Pass("This passes");
        }
    }
}
