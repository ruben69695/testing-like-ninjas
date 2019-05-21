namespace MagicDarkLibraries.Calculator
{
    public class SubtractOperation : IOperation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int? Result { get; private set; }

        public SubtractOperation(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int MakeOperation()
        {
            int operationResult = X - Y;

            Result = operationResult;

            return operationResult;
        }
    }
}