namespace MagicDarkLibraries.Calculator
{
    public interface IOperation
    {
        int X { get; set; }
        int Y { get; set; }
        int? Result { get; }
        
        int MakeOperation();
    }
}