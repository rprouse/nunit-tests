using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v2
{
    [TestFixture]
    public class AsyncTests
    {
        [Test]
        [Description("Testing nunit/nunitv2#15 async support in .NET 4.0 using the async support pack")]
        public void AsyncTest()
        {
            Assert.That(async () => await AsyncReturnOne(), Is.EqualTo(1));
        }

        private static Task<int> AsyncReturnOne()
        {
            return Task.Run(() => 1);
        }
    }
}
