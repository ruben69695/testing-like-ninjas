namespace TrollLibraries.CodeKatasStack
{
    public class MyStack<T>
    {
        private readonly int _count;
        private readonly T _item;
        private readonly MyStack<T> _previousStack;

        public int Count => _count;

        public MyStack() {
            _previousStack = null;
            _count = 0;
            _item = default(T);
        }

        private MyStack(MyStack<T> previousStack, T item, int count) {
            _previousStack = previousStack;
            _count = count;
            _item = item;
        }

        public MyStack<T> Push(T item) {
            return new MyStack<T>(this, item, _count + 1);
        }

        public T Peek() {
            return _item;
        }

        public MyStack<T> Pop() {
            return _previousStack;
        }
    }
}
