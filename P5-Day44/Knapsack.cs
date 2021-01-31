using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms
{
    class Knapsack
    {
        private int[] weights { get; set; }
        private int[] values { get; set; }
        private int bagCapacity;

        public Knapsack(int[] values, int[] weights, int bagCapacity)
        {
            this.values = values;
            this.weights = weights;
            this.bagCapacity = bagCapacity;
        }
        // Dynamic Programming, store results in array
        public int SolveKnapsack()
        {
            int itemsCount = values.Length;
            int[,] results = new int[itemsCount + 1, bagCapacity + 1];

            for (int i = 0; i <= itemsCount; i++)
            {
                for (int w = 0; w <= bagCapacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        results[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)
                    {
                        results[i, w] = Math.Max(values[i - 1] + results[i - 1, w - weights[i - 1]], results[i - 1, w]);
                    }
                    else
                    {
                        results[i, w] = results[i - 1, w];
                    }
                }
            }
            return results[itemsCount, bagCapacity];
        }
    }
}
