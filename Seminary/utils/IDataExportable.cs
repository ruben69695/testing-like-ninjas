namespace utils 
{
    public interface IDataExportable
    {
        ISerializer Serializer { get; }
        bool Export<TData> (TData item, IWritable destination) where TData : class;
    }
}