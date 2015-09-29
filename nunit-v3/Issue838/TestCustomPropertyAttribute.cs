using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3.Issue838
{
    [TestFixture]
    public class TestCustomPropertyAttribute
    {
        [Test]
        [CustomProperty(CustomPropertyType.First)]
        public void MinimumWorkingTest()
        {
            Assert.Pass("This passes!");
        }
    }
    public enum CustomPropertyType
    {
        First,
        Second
    }

    public class CustomPropertyAttribute : PropertyAttribute
    {
        public CustomPropertyAttribute(CustomPropertyType type)
            : base(type)
        {
        }
    }
}
