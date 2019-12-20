using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class DynamicTests
    {
        [Test]
        public void DynamicPropertyTest()
        {
            dynamic dyn = new
            {
                Name = "Rob",
                Country = "Canada"
            };

            Assert.That(dyn, Has.Property("Name"));
            Assert.That(dyn, Has.No.Property("Age"));
        }
    }
}
