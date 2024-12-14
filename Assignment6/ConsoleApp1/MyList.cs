

using System;

namespace ConsoleApp1
{
    public class MyList<T>
    {
        T[] _list;
        int _size;
        int _capacity;

        public MyList(int capacity = 4)
        {
            _capacity = capacity;
            _list = new T[_capacity];
            _size = 0;
        }

        private void Resize()
        {

            _capacity *= 2;
            T[] newList = new T[_capacity];
            Array.Copy(_list, 0, newList, 0, _size);
            _list = newList;

        }

        public void Add(T item)
        {
            if (_capacity == _size)
            {
                Resize();
            }
            _list[_size] = item;
            _size += 1;
        }

        private void ShiftRight(int index)
        {
            for (int i = _size; i > index; i--)
            {
                _list[i] = _list[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < _size - 1; i++)
            {
                _list[i] = _list[i + 1];
            }
        }

        public T Remove(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            T result = _list[index];

            ShiftLeft(index);
            _size -= 1;
            _list[_size] = default(T);
            return result;

        }

        public bool Contains(T element)
        {
            if (element == null)
            {
                return false;
            }
            for (int i = 0; i < _size; i++)
            {
                if (element.Equals(_list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _list = new T[_capacity];
            _size = 0;
        }

        public void InsertAt(T element, int index)

        {
            if (index > _size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (_capacity == _size)
            {
                Resize();
            }

            ShiftRight(index);
            _list[index] = element;
            _size+=1;

        }

        public void DeleteAt(int index)
        {
            Remove(index);
        }

        public T Find(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _list[index];
        }

    }
}
