using System;
using System.IO;

namespace utils
{
    public class FileSerializer : IFileSerializer
    {
        private readonly ISerializer _serializer;

        public FileSerializer(ISerializer serializer)
        { 
            _serializer = serializer;
        }

        public ISerializer Serializer => _serializer;

        public bool SerializeToFile<T>(T item, string fileName) where T : class
        {
            if(string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if(item == null)
                throw new ArgumentNullException(nameof(item));
            
            bool serialized = false;
            string data = _serializer.Serialize(item);

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(data);
                serialized = true;
            }

            return serialized;
        }
    }
}