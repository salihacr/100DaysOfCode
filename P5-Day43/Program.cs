using System;

namespace AdvancedAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4;
            int[,] board = new int[N, N];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }

            Queen nQueen = new Queen(N);
            nQueen.SolveNQueen(board);



            Console.ReadKey();
        }
    }
}
