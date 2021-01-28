using System;

namespace _100DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 98, 25, 34, 12, 56, 41, 81, 34, 36, 23, 7, 10 };
            int[] sortedArray = { 7, 10, 12, 23, 25, 34, 41, 56, 81, 98 };

            // Linear Search
            Console.WriteLine("Linear Search");
            LinearSearch(testArray, 34);
            LinearSearch(testArray, 7);
            // Binary Search
            Console.WriteLine("Binary Search");
            BinarySearch(sortedArray, 34);
            BinarySearch(sortedArray, 7);
            BinarySearch(sortedArray, 98);
            // Recursive Binary Search
            Console.WriteLine("Recursive Binary Search");
            RecursiveBinarySearch(sortedArray, 34, 0, sortedArray.Length - 1);
            RecursiveBinarySearch(sortedArray, 7, 0, sortedArray.Length - 1);
            RecursiveBinarySearch(sortedArray, 98, 0, sortedArray.Length - 1);

            Console.ReadKey();
        }
        #region Linear Search
        private static int[] LinearSearchUtil(int[] list, int searchedElement)
        {
            int[] result = new int[list.Length];
            int j = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == searchedElement)
                {
                    result[j] = i;
                    j++;
                }
            }
            return result;
        }
        private static int[] LinearSearch(int[] list, int searchedElement)
        {
            int[] result = LinearSearchUtil(list, searchedElement);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The searched number (" + searchedElement + ") was found in the " + result[i] + " index");
                }
            }
            return result;
        }
        #endregion Linear Search

        #region BinarySearch
        private static int BinarySearch(int[] list, int searchedElement)
        {
            int firstIndex = 0;
            int lastIndex = list.Length - 1;
            bool found = false;

            while (firstIndex <= lastIndex)
            {
                int middleIndex = (lastIndex + firstIndex) / 2;

                if (list[middleIndex] == searchedElement)
                {
                    found = true;
                    Console.WriteLine("The searched number (" + searchedElement + ") was found in the " + middleIndex + " index");
                    return middleIndex;
                }
                else if (searchedElement < list[middleIndex])
                {
                    lastIndex = middleIndex - 1;
                }
                else
                {
                    firstIndex = middleIndex + 1;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Not Found");
            }
            return -1;
        }
        public static int RecursiveBinarySearchUtil(int[] list, int searchedElement, int firstIndex, int lastIndex)
        {
            if (firstIndex > lastIndex)
            {
                return -1;
            }
            else
            {
                int middleIndex = (lastIndex + firstIndex) / 2;

                if (list[middleIndex] == searchedElement)
                {
                    return middleIndex;
                }
                if (searchedElement < list[middleIndex])
                {
                    return RecursiveBinarySearchUtil(list, searchedElement, firstIndex, middleIndex - 1);
                }
                else
                {
                    return RecursiveBinarySearchUtil(list, searchedElement, middleIndex + 1, lastIndex);
                }
            }
        }
        public static int RecursiveBinarySearch(int[] list, int searchedElement, int firstIndex, int lastIndex)
        {
            int result = RecursiveBinarySearchUtil(list, searchedElement, firstIndex, lastIndex);
            if (result != -1)
            {
                Console.WriteLine("The searched number (" + searchedElement + ") was found in the " + result + " index");
                return result;
            }
            else
            {
                Console.WriteLine("Not Found");
                return -1;
            }
        }
        #endregion
    }
}