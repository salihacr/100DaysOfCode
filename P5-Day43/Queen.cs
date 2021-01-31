using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms
{
    class Queen
    {
        public int N { get; set; }

        public Queen(int N)
        {
            this.N = N; // Count of Queens
        }

        // Utility Function to check if a queen can be placed on board[row,col]
        private bool IsSafe(int[,] board, int row, int col)
        {
            // Check this row on left side
            for (int i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            // Check upper diagonal on left side
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            // Check lower diagonal on left side
            for (int i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        // A recursive function to solve N Queen problem
        private bool SolveNQUtil(int[,] board, int col)
        {
            // base case : if all queens are placed
            if (col >= this.N)
                return true;

            for (int i = 0; i < this.N; i++)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;

                    // Recursive to place rest of the queens.
                    if (SolveNQUtil(board, col + 1) == true)
                        return true;

                    // If placing queen in board[i,col] doesnt lead to solution then remove queen from board[i,col]
                    board[i, col] = 0; // Backtrack
                }
            }
            // If the queen can't placed in any row in this column, then return false
            return false;
        }

        public bool SolveNQueen(int[,] board)
        {
            if (SolveNQUtil(board, 0) == false)
            {
                Console.Write("Solution does not exist");
                return false;
            }
            PrintSolution(board);
            return true;
        }

        private void PrintSolution(int[,] board)
        {
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.N; j++)
                {
                    Console.Write(" " + board[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
