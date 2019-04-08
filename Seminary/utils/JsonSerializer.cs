using System;
using Newtonsoft.Json;

namespace utils
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T item) where T : class
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            return JsonConvert.SerializeObject(item);
        }
    }
}
