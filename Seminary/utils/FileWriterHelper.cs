using System;
using System.IO;

namespace utils
{
    public class FileWriterHelper : IWritable
    {
        public string DestinationFile { get; private set; }

        public FileWriterHelper(string destinationFile)
        {
            DestinationFile = destinationFile;
        }

        public bool Write(string data)
        {
            bool operationResult = false;

            using (StreamWriter outputFile = new StreamWriter(DestinationFile))
            {
                outputFile.WriteLine(data);
                operationResult = true;
            }

            return operationResult;
        }
    }
}