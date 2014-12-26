// ***********************************************************************
// Copyright (c) 2009 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Threading;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework
{
    /// <summary>
    /// ExpectedExceptionAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ExpectedExceptionAttribute : NUnitAttribute, ICommandDecorator
    {
        private ExpectedExceptionData _exceptionData = new ExpectedExceptionData();

        /// <summary>
        /// Constructor for a given type of exception
        /// </summary>
        /// <param name="exceptionType">The type of the expected exception</param>
        public ExpectedExceptionAttribute(Type exceptionType)
        {
            _exceptionData.ExpectedExceptionType = exceptionType;
        }

        /// <summary>
        /// Gets or sets the expected exception type
        /// </summary>
        public Type ExpectedException
        {
            get { return _exceptionData.ExpectedExceptionType; }
            set { _exceptionData.ExpectedExceptionType = value; }
        }

        /// <summary>
        /// Gets or sets the user message displayed in case of failure
        /// </summary>
        public string UserMessage
        {
            get { return _exceptionData.UserMessage; }
            set { _exceptionData.UserMessage = value; }
        }

        #region ICommandDecorator Members

        TestCommand ICommandDecorator.Decorate(TestCommand command)
        {
            return new ExpectedExceptionCommand(command, _exceptionData);
        }

        #endregion
    }

    public class ExpectedExceptionCommand : DelegatingTestCommand
    {
        private ExpectedExceptionData _exceptionData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedExceptionCommand"/> class.
        /// </summary>
        /// <param name="innerCommand">The inner command.</param>
        /// <param name="exceptionData">The exception data.</param>
        public ExpectedExceptionCommand(TestCommand innerCommand, ExpectedExceptionData exceptionData)
            : base(innerCommand)
        {
            _exceptionData = exceptionData;
        }


        /// <summary>
        /// Runs the test, saving a TestResult in the supplied TestExecutionContext
        /// </summary>
        /// <param name="context">The context in which the test is to be run.</param>
        /// <returns>A TestResult</returns>
        public override TestResult Execute(TestExecutionContext context)
        {
            try
            {
                context.CurrentResult = innerCommand.Execute(context);

                if (context.CurrentResult.ResultState == ResultState.Success)
                    ProcessNoException(context);
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException)
                    Thread.ResetAbort();

                ProcessException(ex, context);
            }

            return context.CurrentResult;
        }

        /// <summary>
        /// Handles processing when no exception was thrown.
        /// </summary>
        /// <param name="context">The execution context.</param>
        private void ProcessNoException(TestExecutionContext context)
        {
            context.CurrentResult.SetResult(ResultState.Failure, NoExceptionMessage());
        }

        /// <summary>
        /// Handles processing when an exception was thrown.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="context">The execution context.</param>
        private void ProcessException(Exception exception, TestExecutionContext context)
        {
            if (exception is NUnitException)
                exception = exception.InnerException;

            if (IsExpectedExceptionType(exception))
            {
                context.CurrentResult.SetResult(ResultState.Success);
            }
            else
            {
                context.CurrentResult.RecordException(exception);

                // If it shows as an error, change it to a failure due to the wrong type
                if (context.CurrentResult.ResultState == ResultState.Error)
                    context.CurrentResult.SetResult(ResultState.Failure, WrongTypeMessage(exception), ExceptionHelper.GetStackTrace(exception));
            }
        }

        #region Helper Methods

        private bool IsExpectedExceptionType(Exception exception)
        {
            return _exceptionData.ExpectedExceptionName == null ||
                _exceptionData.ExpectedExceptionName.Equals(exception.GetType().FullName);
        }

        private string NoExceptionMessage()
        {
            string expectedType = _exceptionData.ExpectedExceptionName ?? "An Exception";
            return CombineWithUserMessage(expectedType + " was expected");
        }

        private string WrongTypeMessage(Exception exception)
        {
            return CombineWithUserMessage(
                "An unexpected exception type was thrown" + Env.NewLine +
                "Expected: " + _exceptionData.ExpectedExceptionName + Env.NewLine +
                " but was: " + exception.GetType().FullName + " : " + exception.Message);
        }

        private string CombineWithUserMessage(string message)
        {
            if (_exceptionData.UserMessage == null)
                return message;
            return _exceptionData.UserMessage + Env.NewLine + message;
        }

        #endregion
    }

    /// <summary>
    /// ExpectedExceptionData is a struct used within the framework
    /// to encapsulate information about an expected exception.
    /// </summary>
    public struct ExpectedExceptionData
    {
        #region Fields

        private Type _expectedExceptionType;
        private string _expectedExceptionName;

        #endregion

        #region Properties

        /// <summary>
        /// The Type of any exception that is expected.
        /// </summary>
        public Type ExpectedExceptionType
        {
            get { return _expectedExceptionType; }
            set
            {
                _expectedExceptionType = value;
                _expectedExceptionName = value.FullName;
            }
        }

        /// <summary>
        /// The FullName of any exception that is expected
        /// </summary>
        public string ExpectedExceptionName
        {
            get { return _expectedExceptionName; }
        }

        /// <summary>
        /// A user message to be issued in case of error
        /// </summary>
        public string UserMessage { get; set; }

        #endregion
    }
}