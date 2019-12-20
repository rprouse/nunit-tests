using System;
using NUnit.Framework;

namespace nunit.v3
{
    [TestFixture]
    public class FlakyTest
    {
        [Test]
        [Retry(5)]
        public void TestFlakyMethod()
        {
            int result = 0;
            try
            {
                result = FlakyAdd(2, 2);
            }
            catch(Exception ex)
            {
                Assert.Fail($"Test failed with unexpected exception, {ex.Message}");
            }
            Assert.That(result, Is.EqualTo(4));
        }

        int count2 = 0;

        int FlakyAdd(int x, int y)
        {
            if(count2++ == 2)
                throw new ArgumentOutOfRangeException();

            return x + y;
        }
                
        [Test]
        [Retry(2)]
        public void TestFlakySubtract()
        {
            Assert.That(FlakySubtract(4, 2), Is.EqualTo(2));
        }

        int count = 0;

        int FlakySubtract(int x, int y)
        {
            count++;
            return count == 1 ? 42 : x - y;
        }
    }
}
