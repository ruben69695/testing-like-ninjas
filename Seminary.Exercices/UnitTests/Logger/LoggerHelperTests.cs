using System;
using MagicDarkLibraries.Logger;
using NUnit.Framework;

namespace TestingLikeNinjas.UnitTests.Logger
{
    [TestFixture]
    public class LoggerHelperTests : ILogger
    {
        private LoggerHelper _loggerHelper;
        private bool _isLogErrorMethodCalled;

        [SetUp]
        public void Setup()
        {
            _loggerHelper = new LoggerHelper(this);
        }

        [Test]
        public void LogError_CallMethod_LogError()
        {
            _loggerHelper.LogError("error1");
            
            Assert.That(_isLogErrorMethodCalled, Is.True);
        }

        [Test]
        public void LogError_CallMethod_ShouldSetLastErrorProperty()
        {
            _loggerHelper.LogError("error2");
            
            Assert.That(_loggerHelper.LastError, Is.EqualTo("error2"));
        }

        [Test]
        public void LogError_CallMethod_ShouldRaiseErrorLoggedEvent()
        {
            bool eventRaised = false;

            _loggerHelper.ErrorLogged += (sender, guid) => eventRaised = true;
            _loggerHelper.LogError("error3");
            
            Assert.That(eventRaised, Is.True);            
        }

        [Test]
        public void LogError_PassEmptyError_ShouldThrowArgumentNullException()
        {
            Assert.That(() => _loggerHelper.LogError(string.Empty), 
                Throws.ArgumentNullException);
        }

        #region ILogger Implementation

        public void LogError(string textError)
        {
            Console.WriteLine("Dependency Injection is Awesome!");

            if (textError == "error1")
                _isLogErrorMethodCalled = true;
        }

        #endregion
    }
}