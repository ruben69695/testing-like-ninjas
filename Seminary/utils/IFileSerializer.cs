namespace utils 
{
    public interface IFileSerializer
    {
        ISerializer Serializer { get; }
        bool SerializeToFile<T> (T item, string fileName) where T : class;
    }
}