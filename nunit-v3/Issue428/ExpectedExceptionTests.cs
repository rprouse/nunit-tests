using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3.Issue428
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HandlesArgumentExceptionAsType()
        {
            throw new ArgumentException();
        }
    }
}
