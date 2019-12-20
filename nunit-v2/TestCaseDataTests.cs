﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nunit.v2
{
    [TestFixture]
    public class TestCaseDataTests
    {
        public static IEnumerable<TestCaseData> Data()
        {
            yield return new TestCaseData(new [] { new string[] { "XS", "XL", "M" }});
            yield return new TestCaseData(new[] { new string[] { "S", "M", "XXL", "L" } });
        }

        [TestCaseSource(nameof(Data))]
        public void TestStringArrayArguments(string[] sizes)
        {
            Assert.That(sizes.Length, Is.GreaterThan(1));
        }
    }
}
