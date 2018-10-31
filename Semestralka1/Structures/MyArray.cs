
using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class MyArray<TD> : IEnumerable<TD>
    {
        private int _count;
        private TD[] _array;

        public MyArray()
        {
            _array = new TD[4];
            _count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TD> GetEnumerator()
        {

            for (int j = 0; j < _count; j++)
            {
                yield return _array[j];
            }
        }

        public void Add(TD data)
        {
            if (_count == _array.Length)
            {
                IncreaseSize();
            }
            _array[_count] = data;
            _count++;
        }

        public void Remove(int index)
        {
            if (index < _count)
            {
                _array[index] = default(TD);
                _count--;
            }
        }

        public TD Get(int index)
        {
            return _array[index];
        }

        private void IncreaseSize()
        {
            var pom = _array;
            _array = new TD[_array.Length * 2];
            pom.CopyTo(_array, 0);
        }

        public bool IsEmpty()
        {
            if (_count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count()
        {
            return _count;
        }
    }
}
