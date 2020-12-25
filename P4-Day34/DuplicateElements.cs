using System;
using System.Collections.Generic;

namespace _100DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 1, 3, 4, 8, 2, 7, 8, 8, 3 };
            duplicateElements(arr);

            int[] arr2 = new int[] { 2, 4, 5, 11, 33, 2, 5, 55, 100, 1, 5 };
            duplicateElements(arr2);

            Console.ReadKey();
        }
        // This function to find the Duplicates, if duplicate occurs 2 times or more than 2 times in array so, 
        // it will print duplicate value only once at output.
        static void duplicateElements(int[] array)
        {
            bool ifPresent = false;
            List<int> duplicates = new List<int>();
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        if (duplicates.Contains(array[i]))
                        {
                            break;
                        }
                        else
                        {
                            duplicates.Add(array[i]);
                            ifPresent = true;
                        }
                    }
                }
            }
            if (ifPresent == true)
            {
                Console.Write("[" + duplicates[0] + ", ");
                for (int i = 1; i < duplicates.Count - 1; i++)
                {
                    Console.Write(duplicates[i] + ", ");
                }
                Console.Write(duplicates[duplicates.Count - 1] + "]" + "\n");
            }
            else
            {
                Console.Write("No duplicates present in arrays");
            }
        }
    }
}