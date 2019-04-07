using System;

namespace MagicDarkLibraries.Logger
{    
    public class LoggerHelper
    {
        public string LastError { get; private set; }

        public event EventHandler<Guid> ErrorLogged;

        private readonly ILogger _logger;
        
        public LoggerHelper(ILogger loggerImplementation)
        {
            _logger = loggerImplementation;
        }

        public void LogError(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            LastError = text;

            _logger.LogError(text);
            
            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}