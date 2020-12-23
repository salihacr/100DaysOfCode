using System;

namespace _100DaysOfCode
{

    class Program
    {
        static void Main(string[] args)
        {
            Util craps = new Util();
            int NUMBER_OF_GAME_TOURS = 1000;

            /*Method 1*/
            craps.startGame(NUMBER_OF_GAME_TOURS);

            /*Method 2*/
            int win_count = 0;
            for (int i = 0; i < NUMBER_OF_GAME_TOURS; i++)
            {
                win_count += craps.playGame();
            }
            double probability = (double)win_count / NUMBER_OF_GAME_TOURS;
            Console.WriteLine("Method 2 => Win Probability : {0}", probability);


            Console.ReadKey();
        }
    }
    class Util
    {
        static int rollTheDice()
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);

            return dice1 + dice2;
        }
        static int reRollTheDice(int previousTotalDicePoint)
        {
            int newTotalDicePoint;
            while (true)
            {
                newTotalDicePoint = rollTheDice();
                if (newTotalDicePoint == previousTotalDicePoint)
                {
                    return 1;
                }
                if (newTotalDicePoint == 7)
                {
                    return 0;
                }
            }
        }
        public int playGame()
        {
            int diceTotal = rollTheDice();

            switch (diceTotal)
            {
                case 2:
                case 3:
                case 12:
                    return 0;
                case 7:
                case 11:
                    return 1;
                default:
                    return reRollTheDice(diceTotal);
            }
        }
        public double startGame(int tour_count)
        {
            int win_count = 0;
            for (int i = 0; i < tour_count; i++)
            {
                win_count += playGame();
            }
            double probability = (double)win_count / tour_count;
            Console.WriteLine("Method 1 => Win Probability : % {0}", (100 * probability));
            return probability;
        }
    }
}