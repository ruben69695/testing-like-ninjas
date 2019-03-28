using System;

namespace MagicDarkLibraries.Logger
{
    public class DatabaseLogger : ILogger
    {
        public void LogError(string textError)
        {
            Console.WriteLine($"This {textError} is going to a database...");
        }
    }
}