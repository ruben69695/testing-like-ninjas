using System;

namespace TrollLibraries.Logger
{
    public enum LoggerType
    {
        File = 0,
        Database = 1,
        RestService = 2
    }
    
    public class LoggerHelper
    {
        public string LastError { get; private set; }

        public event EventHandler<Guid> ErrorLogged;

        private readonly LoggerType _loggerType;
        
        public LoggerHelper(LoggerType loggerType)
        {
            _loggerType = loggerType;
        }

        public void LogError(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            LastError = text;

            MakeLogRealHappy(text);
            
            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }

        private void MakeLogRealHappy(string text)
        {
            switch (_loggerType)
            {
                case LoggerType.File:
                    Console.WriteLine($"This {text} is going to a file...");
                    break;
                case LoggerType.Database:
                    Console.WriteLine($"This {text} is going to a database...");
                    break;
                case LoggerType.RestService:
                    Console.WriteLine($"This {text} is going to an https rest service on the cloud...");
                    break;
                default:
                    Console.WriteLine($"What the hell do I do with this {text} dude?");
                    break;
            }
        }
    }
}