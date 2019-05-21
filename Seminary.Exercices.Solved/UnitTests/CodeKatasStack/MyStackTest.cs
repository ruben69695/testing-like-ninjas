using NUnit.Framework;
using TestingLikeNinjas.MagicDarkLibraries.CodeKatasStack;

namespace TestingLikeNinjas.UnitTests.CodeKatasStack
{
    [TestFixture]
    public class MyStackTest
    {
        private MyStack<string> _stack;
        
        [SetUp]
        public void Setup()
        {
            _stack = new MyStack<string>();
        }

        [Test]
        public void Push_PushAnItem_ReturnStackWithThePushedItem()
        {
            var stack = _stack.Push("foo");
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Push_PushAnItem_SourceStackIsImmutableDueOperation()
        {
            _stack.Push("foo");
            Assert.That(_stack.Count, Is.Zero);
        }

        [Test]
        public void Peek_PeekAnItem_ShouldReturnLastItem()
        {
            var stack = _stack.Push("foo");
            stack = stack.Push("bar");
            Assert.That(stack.Peek(), Is.EqualTo("bar"));
        }

        [Test]
        public void Pop_PopOffLastItem_ShouldReturnAnStackWithoutThePoppedItem()
        {
            var stack = _stack.Push("foo");
            stack = stack.Pop();
            Assert.That(stack.Count, Is.Zero);
        }
    }
}
