using System;
using System.Collections.Generic;
using System.Linq;

namespace _100DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            bool playGame = true;
            List<int> scores = new List<int>();
            while (playGame)
            {
                Console.Write("Do you want to play the game ? (Yes or No) : ");
                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "yes":

                        Console.Write("Field Size (this value must be between 3 and 25) : ");
                        var fieldSize = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Degree of Difficulty (this value must be between 20 and 80) : ");
                        var degreeOfDifficulty = Convert.ToInt16(Console.ReadLine());

                        if (((fieldSize >= 3 && fieldSize <= 25) && (degreeOfDifficulty >= 20 && degreeOfDifficulty <= 80)))
                        {
                            MineFieldGame mineField = new MineFieldGame(fieldSize, degreeOfDifficulty);
                            var score = mineField.startGame();
                            scores.Add(score);
                            Console.WriteLine("Best score is {0}", scores.Max());
                        }
                        else
                        {
                            Console.WriteLine("Please check and re-enter the values.");
                        }
                        break;
                    case "no":
                        playGame = false;
                        break;
                    default:
                        Console.WriteLine("Yes or No");
                        break;
                }
            }
        }
    }
    interface IGame
    {
        int startGame();
    }
    class Game : IGame
    {
        public virtual int startGame()
        {
            return 0;
        }
    }
    interface IMineFieldGame
    {
        int[,] createMinefield();
        string[,] createResponseField();
        void printMineFieldGeneric<T>(ref T[,] matrix);
    }
    class MineFieldGame : Game, IMineFieldGame
    {
        public int fieldSize { get; set; }
        public double degreeOfDifficulty { get; set; }

        public MineFieldGame(int fieldSize, double degreeOfDifficulty)
        {
            this.fieldSize = fieldSize;
            this.degreeOfDifficulty = degreeOfDifficulty;
        }
        public int[,] createMinefield()
        {
            int mineSize = (int)(this.fieldSize * this.fieldSize * (this.degreeOfDifficulty / 100));
            Console.WriteLine("Mine Size : " + mineSize);
            int[,] field = new int[this.fieldSize, this.fieldSize];
            Random random = new Random();
            int row, column;
            // Mines are placed in the matrix.
            for (int i = 0; i < mineSize; i++)
            {
                row = random.Next(0, this.fieldSize);
                column = random.Next(0, this.fieldSize);
                if (field[row, column] != 1)
                {
                    field[row, column] = 1;
                }
                else
                {
                    i--;
                }
            }
            // "0" is added to non-mine cells. These cells are score cells.
            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    if (field[i, j] != 1)
                    {
                        field[i, j] = 0;
                    }
                }
            }
            Console.WriteLine("Minefield created...");
            return field;
        }
        // This function creates the answer matrix.
        public string[,] createResponseField()
        {
            string[,] responseMatrix = new string[this.fieldSize, this.fieldSize];
            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    responseMatrix[i, j] = "*";
                }
            }
            return responseMatrix;
        }
        // This function displays the given matrix on the screen regardless of the type.
        public void printMineFieldGeneric<T>(ref T[,] matrix)
        {
            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // This function works until you lose the game.
        public override int startGame()
        {
            Random random = new Random();
            int[,] minefield = createMinefield();
            string[,] responseField = createResponseField();
            Console.WriteLine("Game is start, have a good time ! The values you enter must be between {0} and {1}.", 1, this.fieldSize);
            printMineFieldGeneric(ref responseField);

            int score = 0;
            bool gameGoingOn = true;

            while (gameGoingOn)
            {
                Console.Write("Row : ");
                var row = Convert.ToInt16(Console.ReadLine()) - 1;
                //var row = random.Next(1, minefield.GetLength(0)) - 1; // random
                Console.Write("Column : ");
                var column = Convert.ToInt16(Console.ReadLine()) - 1;
                //var column = random.Next(1, minefield.GetLength(1)) - 1; // random

                try
                {
                    if ((row < this.fieldSize && row >= 0) && (column < this.fieldSize && column >= 0))
                    {
                        if (minefield[row, column] == 1)
                        {
                            printMineFieldGeneric(ref minefield);
                            Console.WriteLine("Game is over, Your score is : {0}", score);
                            gameGoingOn = false;
                        }
                        else
                        {
                            if (responseField[row, column] != "0")
                            {
                                score += 10;
                                responseField[row, column] = "0";
                                printMineFieldGeneric(ref responseField);
                            }
                            else
                            {
                                Console.WriteLine("These values have already been entered. Please re-enter row and column values.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input Error. Please re-enter row and column values.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Unknown error has occurred. Please start the game again.");
                }
            }
            return score;
        }
    }
}