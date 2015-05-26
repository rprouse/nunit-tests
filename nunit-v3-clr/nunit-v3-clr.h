// nunit-v3-clr.h

#pragma once

using namespace NUnit::Framework;

using namespace System;

namespace nunitv3clr {

    [TestFixture]
	public ref class Class1
	{
    public:
        [Test]
        void TestCppCliWorks()
        {
            Assert::Pass("This is a C++/CLI Test");
        }
	};
}
