using System;

namespace AdvancedAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Knapsack knapsack = new Knapsack(new int[] { 60, 40, 100, 120 }, new int[] { 10, 40, 20, 30 }, 50);

            int result = knapsack.SolveKnapsack();

            Console.WriteLine("Total Value : " + result);

            Console.ReadKey();
        }
    }
}
