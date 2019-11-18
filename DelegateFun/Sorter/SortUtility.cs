using System;

namespace Sorter
{
    public static class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public delegate bool SortingTypeFuction(int i, int j);

        public static void InsertionSort(int[] items, SortingTypeFuction compare)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if(compare is null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (compare(items[j - 1], items[j]))
                    {
                        int tempPlaceHolder = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = tempPlaceHolder;
                    }
                }
            }

        }
    }
}
