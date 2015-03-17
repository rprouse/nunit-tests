using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace nunit.v3.Issue318
{
    public class EmptyDbAttribute : TestActionAttribute
    {
        public override void BeforeTest(ITest aTestDetails)
        {
            var lTest = aTestDetails as Test;
            if (lTest.Fixture == null)
            {
                throw new ApplicationException("The fixture is unexpectedly null");
            }
            var lDbTest = lTest.Fixture as IDbTest;
            if (lDbTest == null)
            {
                throw new ApplicationException();
            }
            lDbTest.DbConnection = lDbTest.DbType;
        }
    }

    public interface IDbTest
    {
        string DbType { get; set; }
        string DbConnection { get; set; }
    }

    [EmptyDb]
    [TestFixture("MicrosoftAccess")]
    [TestFixture("SQLite")]
    public class MyDbTest : IDbTest
    {
        public MyDbTest(string aDbType)
        {
            DbType = aDbType;
        }

        public virtual string DbType { get; set; }

        public virtual string DbConnection { get; set; }

        [Test]
        public void MyTest()
        {
            Assert.AreEqual(DbType, DbConnection);
        }
    }
}
