using System.Collections;

namespace GenericsHW
{
    public class Stack<T>
    {
        private const int DefaultSize = 2;
        private T[] _values = new T[DefaultSize];
        private int _currentLength;

        public bool IsEmpty => _currentLength == 0;

        public void Push(T value)
        {
            if(_values.Length <=  _currentLength)
            {
                IncreaseArray();
            }

            _values[_currentLength++] = value;
        }

        public T Pop()
        {
            if (_currentLength == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var result = _values[_currentLength - 1];
            _values[_currentLength - 1] = default;
            _currentLength--;

            return result;
        }

        public T Peek()
        {
            if (_currentLength == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _values[_currentLength - 1];
        }

        private void IncreaseArray()
        {
            var newArray = new T[_values.Length * 2];
            Array.Copy(_values, newArray, _values.Length);
            _values = newArray;
        }
    }
}
