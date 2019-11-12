using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<T> : ICollection<T>
    {
        private List<T> List { get; }
        public int Capacity { get; }
        private int NumberOfItemsInArray { get; set; }

        public int Count => NumberOfItemsInArray;

        public bool IsReadOnly => true;

        
        public ArrayCollection(int size)
        {
            if(size < 0)
            {
                throw new ArgumentNullException(nameof(size));
            }
            List = new List<T>(size);
            Capacity = size;
        }

        public T this[int i]
        {
            get
            {
                if(i > Capacity || i < 0)
                {
                    throw new IndexOutOfRangeException(nameof(i));
                }
                return List[i];
            }

            set
            {
                List.Add(List[i]);
            }
        }

        public void Add(T item)
        {
            if(Count > Capacity || Capacity == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(List.Capacity), "Can't exceed the size of the Array");
            }
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            List.Add(item);
            NumberOfItemsInArray++;
            
        }

        public void Clear()
        {
            List.Clear();
            NumberOfItemsInArray = 0;
        }

        public bool Contains(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if(!List.Contains(item))
            {
                throw new ArgumentException("That item doesn't exist in the Array", nameof(item));
            }

            return List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(arrayIndex >= Capacity)
            {
                throw new ArgumentException("Index value greater than the size of Array", nameof(arrayIndex));
            }
            List.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item), "Item not removed because item is not contained in the Array");
            }

            if(List.Remove(item))
            {
                NumberOfItemsInArray--;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
