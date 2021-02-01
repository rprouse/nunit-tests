using NUnit.Framework;

namespace nunit.v3
{
    [SetUpFixture]
    public class AssemblySetupFixture
    {
        public static int TestIndex { get; private set; } = -1;

        [SetUp]
        public void AssemblySetUp()
        {
            TestIndex += 1;
        }
    }
}
