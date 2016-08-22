using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class CombinatorialTests
    {
        [Combinatorial]
        public void SomeTest([Values] bool flag, [Values(2, 5)] int someValue)
        {
            TestContext.WriteLine($"{flag} - ${someValue}");
        }
    }
}
