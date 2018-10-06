using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3
{
    [TestFixture]
    public class TestCaseDataTests
    {
        public static IEnumerable<TestCaseData> Data()
        {
            yield return new TestCaseData(new[] { new string[] { "XS", "XL", "M" } });
            yield return new TestCaseData(new[] { new string[] { "S", "M", "XXL", "L" } });
        }

        [TestCaseSource(nameof(Data))]
        public void TestStringArrayArguments(string[] sizes)
        {
            Assert.That(sizes.Length, Is.GreaterThan(1));
        }

        private static IEnumerable _byteArrays = new object[]
        {
            new TestCaseData(new byte[] { 80 }), // - works fine with commented out
            new byte[] { 80, 75 },
            new byte[] { 80, 75, 03 }
        };

        [Test]
        [TestCaseSource("_byteArrays")]
        public void TestStuff(byte[] byteArray)
        {
            Assert.IsFalse(false);
        }

        //public static TestCaseData[] testDataMultiDimensionalByteArray = new TestCaseData[]
        //{
        //    new TestCaseData(
        //        "test",
        //        "another deal",
        //        new byte[,] { { 1, 2 }, { 2, 3 } }
        //    )
        //};

        //// this test passes only on 3.8.1, it fails (to even set up the fixture) with the stacktrace above of 3.10.1
        //[TestCaseSource(nameof(testDataMultiDimensionalByteArray))]
        //public void TestThingMultiDimension(string thing, string anotherString, byte[,] multiByte)
        //{
        //    Assert.Pass();
        //}

        [TestCaseSource(nameof(TheData))]
        public void TestData(object i)
        {
            Assert.That(i is int);
        }

        public static IEnumerable TheData => new object[] { 1, 2, 3, 4, 5, /*'a',*/ 6, 7, 8 };
    }
}
