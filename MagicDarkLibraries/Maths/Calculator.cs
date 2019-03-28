using System;

namespace MagicDarkLibraries.Calculator
{   
    public class Calculator
    {
        public IOperation LastOperation { get; private set; }
        
        public Calculator()
        { }

        public int Calculate(IOperation operation)
        {
            int result = operation.MakeOperation();

            LastOperation = operation;
            
            ShowResult(result);

            return result;
        }
        
        private void ShowResult(int result)
        {
            Console.WriteLine($"Se muestra el resultado por pantalla {result}");
        }
        
    }
}