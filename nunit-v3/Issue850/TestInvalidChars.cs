using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace nunit.v3.Issue850
{
    [TestFixture]
    public class TestInvalidChars
    {
        public static IEnumerable<char> InvalidCharacters => Path.GetInvalidFileNameChars();

        // This causes an exception in NUnit 3 beta 4
        //[Test]
        //public void HandleInvalidCharacters([ValueSource("InvalidCharacters")] char invalidCharacter)
        //{
        //}
    }
}
