using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class AsyncTests
    {
        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Async Teardown");
        }

        [Test]
        public async Task AnAsyncTest()
        {
            TestContext.Progress.WriteLine("Before async call");
            await Task.Delay(1000);
            TestContext.Progress.WriteLine("After async call");
        }

        [Test]
        [Ignore("Issue #1190")]
        public void ShouldCatchAsyncExceptions()
        {
            var ioe = Assert.Throws<InvalidOperationException>(async () => await DelayedFailureAsync());
            Assert.That(ioe.Message, Is.EqualTo("ABC"));
        }

        [Test(Description = "Issue #1190")]
        public void ShouldCatchFluentAsyncExceptions()
        {
            Assert.That(async () => await DelayedFailureAsync(), Throws.Exception.TypeOf<InvalidOperationException>().And.Message.EqualTo("ABC"));
        }

        static async Task DelayedFailureAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
            throw new InvalidOperationException("ABC");
        }

        [Test]
        public void TestTheMeaningOfLife()
        {
            Assert.That(async () => await DelayedMeaningOfLife(), Is.EqualTo(42));
        }

        static async Task<int> DelayedMeaningOfLife()
        {
            await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
            return 42;
        }
    }
}
