using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            areHarshedNumbers(2620, 2924);
            areHarshedNumbers(2924, 2620);
            areHarshedNumbers(26, 29);
            areHarshedNumbers(20, 24);
            areHarshedNumbers(10634085, 14084763);
            areHarshedNumbers(23389695, 25132545);
            areHarshedNumbers(34256222, 35997346);

            Console.ReadKey();
        }
        static void mastermindGame(){
            // continues
        }
        /*
            This function checks whether the given two numbers are the number of harshed friends.
        */
        static void areHarshedNumbers(int num1, int num2){
            if (num1 % sumOfDigits(num1) == 0 && num2 % sumOfDigits(num2) == 0){
                Console.WriteLine($"{num1} & {num2} are friends.");
            }
        }
        /*
            This function returns the sum of the digits of the given number recursively.
        */
        static int sumOfDigits(int num) {
            if (num < 1){
                return 0;
            }
            return (num % 10) + (sumOfDigits(num / 10));
        }     
    }
}
