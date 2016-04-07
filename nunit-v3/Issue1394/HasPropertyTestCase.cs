using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3.Issue1394
{
    public interface IFoo
    {
        string Description { get; }
    }

    public class ImplicitFoo : IFoo
    {
        public string Description => "Foo";
    }

    public class ExplicitFoo : IFoo
    {
        string IFoo.Description => "Foo";
    }

    [TestFixture(typeof(ImplicitFoo))]
    //[TestFixture(typeof(ExplicitFoo))]
    public class HasPropertyTestCase<TFoo>
        where TFoo : IFoo, new()
    {
        [Test]
        public void DescriptionIsFoo()
        {
            IFoo thing = new TFoo();
            Assert.That(thing, Has.Property(nameof(IFoo.Description)).EqualTo("Foo"));
        }
    }
}
