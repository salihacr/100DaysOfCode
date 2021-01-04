using System;
using System.Collections.Generic;
using System.Linq;

namespace _100DaysOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleShip battleShipGame = new BattleShip();

            bool playGame = true;
            List<int> scores = new List<int>();
            while (playGame)
            {
                Console.Write("Do you want to play the game ? (Yes or No) : ");
                string answer = Console.ReadLine();
                switch (answer.ToLower())
                {
                    case "yes":
                        var score = battleShipGame.startGame();
                        scores.Add(score);
                        Console.WriteLine("Best score is {0}", scores.Max());
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
    class BattleShip : Game, IBattleShip
    {
        private int fieldSize = 10;

        public int[,] createBattleShipArea()
        {
            int[,] battleShip = new int[this.fieldSize, this.fieldSize];

            Dictionary<int, int> ships = new Dictionary<int, int>();
            ships.Add(1, 4);
            ships.Add(2, 3);
            ships.Add(3, 2);
            ships.Add(4, 1);

            Random generate = new Random();

            int shipRowLen = 0, shipColLen = 0, right = 0, down = 0, shipCount = 0;
            var shipType = 1;

            while (shipType <= 4)
            {
                // direction of ships (0 is right, 1 is down)
                int direction = generate.Next(2);

                if (direction == 0)
                {
                    shipRowLen = this.fieldSize;
                    shipColLen = this.fieldSize - shipType + 1;
                    right = 2 + shipType;
                    down = 3;
                }
                else if (direction == 1)
                {
                    shipRowLen = this.fieldSize - shipType + 1;
                    shipColLen = this.fieldSize;
                    right = 3;
                    down = 2 + shipType;
                }

                var randomRow = generate.Next(shipRowLen);
                var randomCol = generate.Next(shipColLen);

                bool flag = true;
                for (int i = randomRow - 1; i < (randomRow - 1) + down; i++)
                {
                    for (int j = randomCol - 1; j < (randomCol - 1) + right; j++)
                    {
                        if (i >= 0 && i < this.fieldSize && j >= 0 && j < this.fieldSize)
                        {
                            if (battleShip[i, j] != 0)
                            {
                                flag = false;
                            }
                        }
                    }
                }

                if (flag == true)
                {
                    for (int i = randomRow; i < randomRow + down - 2; i++)
                    {
                        for (int j = randomCol; j < randomCol + right - 2; j++)
                        {
                            battleShip[i, j] = shipType;
                        }
                    }
                    shipCount++;

                    var val = 0;
                    ships.TryGetValue(shipType, out val);
                    if (val == shipCount)
                    {
                        shipType += 1;
                        shipCount = 0;
                    }
                }
            }
            Console.WriteLine("Battleship field created...");
            return battleShip;
        }

        public string[,] createResponseField()
        {
            string[,] responseField = new string[this.fieldSize, this.fieldSize];
            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    responseField[i, j] = "*";
                }
            }
            return responseField;
        }

        public void printBattleShipGeneric<T>(ref T[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
        public override int startGame()
        {
            Random random = new Random();
            int[,] battleShip = createBattleShipArea();
            string[,] responseField = createResponseField();

            int numOfStrokes = 0, step = 0, score = 0;

            while (numOfStrokes < 20)
            {
                step += 1;

                Console.Write("Row : ");
                var row = random.Next(1, 11) - 1;
                Console.Write("{0} \n", row);// or next
                //var row =  Convert.ToInt16(Console.ReadLine()) - 1;
                Console.Write("Column : ");
                var column = random.Next(1, 11) - 1;
                Console.Write("{0} \n", column); // or next
                //var column = Convert.ToInt16(Console.ReadLine()) - 1;

                if (battleShip[row, column] != 0)
                {
                    if (responseField[row, column] != "*")
                    {
                        score -= 1;
                        Console.WriteLine("These values have already been entered. Please re-enter row and column values.");
                    }
                    else
                    {
                        numOfStrokes += 1;
                        responseField[row, column] = Convert.ToString(battleShip[row, column]);
                        score += 50;
                    }
                }
                else
                {
                    responseField[row, column] = "X";
                    score -= 2;
                }

                printBattleShipGeneric(ref responseField);
            }
            Console.WriteLine("Battleship field.");
            printBattleShipGeneric(ref battleShip);
            Console.WriteLine("Congratulations! You finished the game in {0} steps. Your score is {1}.", step, score);
            return score;
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
    interface IBattleShip
    {
        int[,] createBattleShipArea();
        string[,] createResponseField();
        void printBattleShipGeneric<T>(ref T[,] matrix);
    }
}