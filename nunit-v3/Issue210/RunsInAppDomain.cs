using System;
using NUnit.Framework;

namespace nunit.v3.Issue210
{
    internal class RunsInAppDomain : MarshalByRefObject
    {
        public void WriteToConsole()
        {
            Console.WriteLine("RunsInAppDomain.WriteToConsole");
        }

        public void WriteToTestContext()
        {
            TestContext.WriteLine("RunsInAppDomain.WriteToTestContext");
        }
    }
}