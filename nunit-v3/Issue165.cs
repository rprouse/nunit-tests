using NUnit.Framework;

namespace nunit.v3
{
    public class Issue165
    {
        [TestCase("Hello")]
        [TestCase("\u0002")]
        public void DoesntStart(string aString)
        {
            Assert.Pass($"Ran Doesn't Start for {aString}");
        }
    }
}
