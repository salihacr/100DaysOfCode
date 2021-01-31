using System;
using System.Collections.Generic;
using System.Text;

namespace _100DaysOfCode
{
    class Sorting
    {
        static void run()
        {
            int[] testArray = { 98, 25, 34, 12, 56, 41, 81, 34, 36, 23, 7, 10 };
            Console.WriteLine("Inital Array");
            PrintArray(testArray);
            // Selection Sort
            Console.WriteLine("Selection Sort");
            PrintArray(SelectionSort(testArray));

            // Bubble Sort
            Console.WriteLine("Bubble Sort");
            PrintArray(BubbleSort(testArray));

            // Merge Sort
            Console.WriteLine("Merge Sort");
            PrintArray(MergeSort(testArray));

            // Quick Sort
            Console.WriteLine("Quick Sort");
            PrintArray(QuickSort(testArray, 0, testArray.Length - 1));

            // Insertion Sort
            Console.WriteLine("Insertion Sort");
            PrintArray(InsertionSort(testArray));

            // Counting Sort
            Console.WriteLine("Counting Sort");
            PrintArray(CountingSort(testArray));

            Console.ReadKey();
        }
        #region Selection Sort
        private static int[] SelectionSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
            return array;
        }
        #endregion

        #region Bubble Sort
        private static int[] BubbleSort(int[] array)
        {
            bool sorted = true;
            for (int i = 0; i < array.Length; i++)
            {
                // for (int j = 1; j < array.Length-i-1; j++)
                for (int j = array.Length - 1; j > i; j--) // more good 
                {
                    if (array[j - 1] > array[j])
                    {
                        sorted = false;
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
                if (sorted)
                {
                    break;
                }
            }
            return array;
        }
        #endregion

        #region Insertion Sort
        private static int[] InsertionSort(int[] array)
        {
            int position, temp;
            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                position = i - 1;
                while (position >= 0 && array[position] > temp)
                {
                    array[position + 1] = array[position];
                    position--;
                }
                array[position + 1] = temp;
            }
            return array;
        }
        #endregion

        #region Counting Sort
        private static int[] CountingSort(int[] array)
        {
            int max = GetMaxValue(array);
            int[] count = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                count[value]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }
            int[] sorted = new int[array.Length];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int value = array[i];
                int position = count[value] - 1;
                sorted[position] = value;

                count[value]--;
            }
            return sorted;
        }
        private static int GetMaxValue(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        #endregion

        #region Merge Sort
        private static int[] MergeSort(int[] array)
        {
            int[] leftArray, rightArray, resultArray = new int[array.Length];

            if (array.Length <= 1)
            {
                return array;
            }

            int middleIndex = array.Length / 2;

            leftArray = new int[middleIndex];

            if (array.Length % 2 == 0)
            {
                rightArray = new int[middleIndex];
            }
            else
            {
                rightArray = new int[middleIndex + 1];
            }
            for (int i = 0; i < middleIndex; i++)
            {
                leftArray[i] = array[i];
            }
            int x = 0;
            for (int i = middleIndex; i < array.Length; i++)
            {
                rightArray[x] = array[i];
                x++;
            }
            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            resultArray = Merge(leftArray, rightArray);

            return resultArray;
        }
        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] combined = new int[leftArray.Length + rightArray.Length];

            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < leftArray.Length || rightIndex < rightArray.Length)
            {
                if (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
                {
                    if (leftArray[leftIndex] <= rightArray[rightIndex])
                    {
                        combined[resultIndex] = leftArray[leftIndex];
                        leftIndex++;
                        resultIndex++;
                    }
                    else
                    {
                        combined[resultIndex] = rightArray[rightIndex];
                        rightIndex++;
                        resultIndex++;
                    }
                }
                else if (leftIndex < leftArray.Length)
                {
                    combined[resultIndex] = leftArray[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else if (rightIndex < rightArray.Length)
                {
                    combined[resultIndex] = rightArray[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }
            return combined;
        }
        #endregion

        #region Quick Sort
        private static int[] QuickSort(int[] array, int start, int last)
        {
            int i;
            if (start < last)
            {
                i = Partition(array, start, last);

                QuickSort(array, start, i - 1);
                QuickSort(array, i + 1, last);
            }
            return array;
        }

        private static int Partition(int[] array, int startIndex, int lastIndex)
        {
            int pivot = array[lastIndex];
            int i = startIndex - 1;
            int temp;

            for (int j = startIndex; j <= lastIndex - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            temp = array[i + 1];
            array[i + 1] = array[lastIndex];
            array[lastIndex] = temp;
            return i + 1;

        }
        #endregion


        public static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
