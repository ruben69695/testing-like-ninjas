using System;

namespace MagicDarkLibraries.Logger
{
    public class FileLogger : ILogger
    {
        public void LogError(string textError)
        {
            Console.WriteLine($"This {textError} is going to a file...");
        }
    }
}