using System;
using System.IO;

namespace utils
{
    public class DataExporter : IDataExportable
    {
        private readonly ISerializer _serializer;

        public DataExporter(ISerializer serializer)
        { 
            _serializer = serializer;
        }

        public ISerializer Serializer => _serializer;

        public bool Export<TData> (TData item, IWritable destination) where TData : class
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));
            if(destination == null)
                throw new ArgumentNullException(nameof(destination));

            bool exportResult = false;

            string serializedData = _serializer.Serialize(item);

            exportResult = destination.Write(serializedData);

            return exportResult;
        }
    }
}