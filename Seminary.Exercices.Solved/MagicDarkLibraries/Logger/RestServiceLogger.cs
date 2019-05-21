using System;

namespace MagicDarkLibraries.Logger
{
    public class RestServiceLogger : ILogger
    {
        public void LogError(string textError)
        {
            Console.WriteLine($"This {textError} is going to an https rest service on the cloud...");
        }
    }
}