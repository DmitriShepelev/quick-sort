using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611
#pragma warning disable CA1062

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            // #1. Implement the method using a loop statements.
            if (array is null)
            {
                throw new ArgumentNullException($"Array can not be null.");
            }

            if (array.Length <= 1)
            {
                return;
            }

            QuickSortIterative(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            // #2. Implement the method using recursion algorithm.
            if (array is null)
            {
                throw new ArgumentNullException($"Array can not be null.");
            }

            if (array.Length == 0)
            {
                return;
            }

            QuickSortRecursive(array, 0, array.Length - 1);
        }

        private static void QuickSortIterative(int[] arr, int left, int right)
        {
            static void Swap(ref int x, ref int y)
            {
                int tmp = x;
                x = y;
                y = tmp;
            }

            static int Partition(int[] array, int left, int right)
            {
                int marker = left;
                for (int i = left; i <= right; i++)
                {
                    if (array[i] < array[right])
                    {
                        Swap(ref array[marker], ref array[i]);
                        marker++;
                    }
                }

                Swap(ref array[marker], ref array[right]);

                return marker;
            }

            int[] stack = new int[arr.Length];
            int sp = -1; // Stack Pointer.

            stack[++sp] = left;
            stack[++sp] = right;

            while (sp >= 0)
            {
                right = stack[sp--];
                left = stack[sp--];
                int pivot = Partition(arr, left, right);

                if (pivot - 1 > left)
                {
                    stack[++sp] = left;
                    stack[++sp] = pivot - 1;
                }

                if (pivot + 1 < right)
                {
                    stack[++sp] = pivot + 1;
                    stack[++sp] = right;
                }
            }
        }

        private static void QuickSortRecursive(int[] array, int left, int right)
        {
            int leftMarker = left;
            int rightMarker = right;
            int pivot = array[(left + right) / 2];

            while (leftMarker <= rightMarker)
            {
                while (array[leftMarker] < pivot)
                {
                    leftMarker++;
                }

                while (array[rightMarker] > pivot)
                {
                    rightMarker--;
                }

                if (leftMarker <= rightMarker)
                {
                    int tmp = array[leftMarker];
                    array[leftMarker] = array[rightMarker];
                    array[rightMarker] = tmp;

                    leftMarker++;
                    rightMarker--;
                }
            }

            if (left < rightMarker)
            {
                QuickSortRecursive(array, left, rightMarker);
            }

            if (leftMarker < right)
            {
                QuickSortRecursive(array, leftMarker, right);
            }
        }
    }
}
