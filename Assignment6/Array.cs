using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private List<T> _List;
        public int Capacity { get; }
        private int numberOfItemsInArray { get; set; }

        public int Count => numberOfItemsInArray;

        public bool IsReadOnly => throw new NotImplementedException();

        
        public Array(int size)
        {
            if(size < 0)
            {
                throw new ArgumentNullException(nameof(size));
            }
            _List = new List<T>(size);
            Capacity = size;
        }

        public void Add(T item)
        {
            if(Count == Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(_List.Count), "Can't exceed the size of the Array");
            }
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _List.Add(item);
            numberOfItemsInArray++;
            
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
