using System;

namespace _100DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spiral Matrix----------------------------");
            spiralMatrix(5);

            int[,] m1 = createMatrix(2, 3);
            int[,] m2 = createMatrix(3, 2);
            Console.WriteLine("Matrix 1----------------------------");
            printMatrix(m1);

            int[,] transposeMatrix = transpose(m1);
            Console.WriteLine("Transpose Matrix 1----------------------------");
            printMatrix(transposeMatrix);

            Console.WriteLine("Matrix 2----------------------------");
            printMatrix(m2);

            int[,] transposeMatrix2 = transpose(m2);
            Console.WriteLine("Transpose Matrix 2----------------------------");
            printMatrix(transposeMatrix2);

            Console.WriteLine("Matrix Multiplication (Matrix1 * Matrix2)----------------------------");
            int[,] m3 = multiplyMatrix(m1, m2);
            if (m3 != null)
            {
                printMatrix(m3);
            }
            Console.ReadKey();
        }
        // This function prints the given matrix to the console.
        static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        // This function returns a matrix of random numbers.
        static int[,] createMatrix(int n, int m)
        {
            Random rnd = new Random();
            int[,] matrix = new int[n, m];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(1, 11);
                }
            }
            return matrix;
        }
        // This function transposes the matrix.
        static int[,] transpose(int[,] Matrix)
        {
            int[,] TransposeMatrix = new int[Matrix.GetLength(1),Matrix.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    TransposeMatrix[j, i] = Matrix[i, j];
                }
            }
            return TransposeMatrix;
        }
        // This function returns the matrix formed by multiplying two matrices.
        static int[,] multiplyMatrix(int[,] Matrix1, int[,] Matrix2)
        {
            int[,] Matrix3 = new int[Matrix1.GetLength(0), Matrix2.GetLength(1)];
            if (Matrix1.GetLength(0) == Matrix2.GetLength(1))
            {
                for (int i = 0; i < Matrix3.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix1.GetLength(0); j++)
                    {
                        Matrix3[i, j] = 0;
                        for (int k = 0; k < Matrix1.GetLength(1); k++)
                        {
                            Matrix3[i, j] += Matrix1[i, k] * Matrix2[k, j];
                        }
                    }
                }
                return Matrix3;
            }
            return null;

        }
        // This function returns a spiral matrix.
        static void spiralMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = n * n;
            for (int i = 1; i <= maxRotations; i++)
            {
                if ((direction == "right") && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if ((direction == "down") && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if ((direction == "left") && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }
                if ((direction == "up") && (row < 0 || matrix[row, col] != 0))
                {
                    direction = "right";
                    row++;
                    col++;
                }
                matrix[row, col] = i;
                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write("{0, 5}", matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}