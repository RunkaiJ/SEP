

namespace ConsoleApp1
{
    public class MyStack<T>
    {
        private T[] _stack;
        private int _size;
        private int _capacity;

        public MyStack(int capacity = 4)
        {
            _capacity = capacity;
            _size = 0;
            _stack = new T[capacity];
        }

        public int Count()
        {
            return _size;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Cannot pop from an empty stack.");
            }
            _size -= 1;
            T result = _stack[_size];
            _stack[_size] = default(T);
            return result;
        }

        public void Push(T item)
        {
        
            if (_size > _capacity)
            {
                _capacity *= 2;
                T[] newStack = new T[_capacity];
                for (int i = 0; i < _size; i++)
                {
                    newStack[i] = _stack[i];
                }
                _stack = newStack;
            }
            _stack[_size] = item;
            _size += 1;

        }

    }
}
