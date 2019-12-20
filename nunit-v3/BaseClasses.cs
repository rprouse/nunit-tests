using NUnit.Framework;

namespace nunit.v3
{
    public class GenericBase<T>
    {
        [Test]
        public void GenericBaseTest()
        {
            Assert.Pass("GenericBase");
        }
    }
    
    public abstract class AbstractBase
    {
        [Test]
        public void AbstractBaseTest()
        {
            Assert.Pass("AbstractBase");
        }

        [Test]
        public void AbstractBaseTest2()
        {
            Assert.Pass("AbstractBase");
        }

        public abstract void MustImplement();
    }
    
    public abstract class AbstractGenericBase<T>
    {
        [Test]
        public void AbstractGenericBaseTest()
        {
            Assert.Pass("AbstractGenericBase");
        }

        public abstract void MustImplement();
    }
}
