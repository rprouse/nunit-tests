using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace nunit.v3.Issue522
{
    public interface ISomeRemoteObject
    {
        string GetSomething();
    }

    public class SomeRemoteObject : MarshalByRefObject, ISomeRemoteObject
    {
        public string GetSomething()
        {
            return "SomeValue";
        }
    }

    [TestFixture]
    public class Issue522
    {
        [SetUp]
        public void Init()
        {
            TcpChannel channel = new TcpChannel(9999);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
               typeof(SomeRemoteObject), "Test",
               WellKnownObjectMode.SingleCall);
        }

        [Test]
        public void FailingTest()
        {
            var target = (ISomeRemoteObject)Activator.GetObject(typeof(ISomeRemoteObject), "tcp://localhost:9999/Test");
            Assert.AreEqual(target.GetSomething(), "SomeValue");
        }

    }
}
