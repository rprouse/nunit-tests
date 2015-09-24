using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunitlite_v3
{
    [TestFixture]
   public class Issue077382
   {
        [TestCase(70400, 7, 4, 0)]
        [TestCase(70401, 7, 4, 1)]
        [TestCase(81499, 8, 14, 99)]
        public void TestMethod(int version, int exRel, int exMaj, int exMin)
        {
            // Issue: 77382 - reformat text in UI so that the version displayed
            //                are like this? 7.4, 7.4.1 instead of 70400, 70401
            var rel = version / 10000;
            var maj = (version / 100) % 100;
            var min = version % 100;

            Assert.That(rel, Is.EqualTo(exRel));
            Assert.That(maj, Is.EqualTo(exMaj));
            Assert.That(min, Is.EqualTo(exMin));
        }
   }
}
