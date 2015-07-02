using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace nunit.v3
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        [Category("PDF")]
        [Category("DOC")]
        public void CanGetCategory()
        {
            IPropertyBag properties = TestContext.CurrentContext.Test.Properties;
            var cat = properties["Category"];
            Assert.That(cat, Contains.Item("PDF"));
            Assert.That(cat, Contains.Item("DOC"));
        }
    }
}
