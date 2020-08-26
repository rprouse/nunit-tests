using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace nunit.v3
{
    public class CloseToTests
    {
        [Test]
        public void CanCompareDatesThatAreClose()
        {
            var actual = DateTime.UtcNow;

            Thread.Sleep(200);

            Assert.That(actual, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromMilliseconds(1000)));
        }
    }
}
