using System;

namespace TrollLibraries.Calculator
{
    public enum MathOperation
    {
        Sum = 0,
        Subtract = 1
    }
    
    public class Calculator
    {
        public int LastResult { get; private set; }
        public int LastX { get; private set; }
        public int LastY { get; private set; }
        public MathOperation LastOperation { get; private set; }
        
        public Calculator()
        {
            
        }
        
        public void Sum(int x, int y)
        {
            LastX = x;
            LastY = y;
            LastOperation = MathOperation.Sum;

            LastResult = x + y;

            ShowResult(LastResult);
        }

        public void Subtract(int x, int y)
        {
            LastX = x;
            LastY = y;
            LastOperation = MathOperation.Subtract;

            LastResult = x - y;

            ShowResult(LastResult);
        }

        private void ShowResult(int result)
        {
            Console.WriteLine($"Se muestra el resultado por pantalla {result}");
        }
    }
}