using MagicDarkLibraries.Calculator;
using NSubstitute;
using NUnit.Framework;

namespace TestingLikeNinjas.UnitTests.Maths
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        private IOperation _operation;

        [SetUp]
        public void Setup()
        {
            _operation = Substitute.For<IOperation>();
            _calculator = new Calculator();
        }

        [Test]
        public void Calculate_MethodCall_ShouldMakeTheOperation()
        {
            _calculator.Calculate(_operation);
            
            // Acts as Assert: Be sure that calculator has called the make operation method inside Calculate function
            _operation
                .Received().MakeOperation();
        }

        [Test]
        public void Calculate_MethodCall_ShouldMakeTheOperationAndReturnResult()
        {
            int operationResult = 0;

            // Prepare a fake result, when MakeOperation is called with the operation mock
            _operation.MakeOperation().Returns(50);
            operationResult = _calculator.Calculate(_operation);
            
            Assert.That(operationResult, Is.EqualTo(50));
        }

        [Test]
        public void Calculate_MethodCall_SaveLastOperation()
        {
            _calculator.Calculate(_operation);
            
            Assert.That(_calculator.LastOperation, Is.EqualTo(_operation));
        }
        
    }
}