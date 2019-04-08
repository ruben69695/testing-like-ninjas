namespace utils 
{
    public interface ISerializer
    {
        string Serialize<T>(T item) where T : class;
    }
}