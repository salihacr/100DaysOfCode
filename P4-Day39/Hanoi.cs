using System;

namespace _100DaysOfCode
{
    class Program
    {
        #region Tower of Hanoi Iterative Solution
        public class Stack
        {
            public int capacity;
            public int top;
            public int[] array;
        }
        Stack CreateStack(int capacity)
        {
            Stack stack = new Stack();
            stack.capacity = capacity;
            stack.top = -1;

            stack.array = new int[capacity];
            return stack;
        }
        bool IsFull(Stack stack)
        {
            return (stack.top == stack.capacity - 1);
        }
        bool IsEmpty(Stack stack)
        {
            return (stack.top == -1);
        }
        void Push(Stack stack, int item)
        {
            if (IsFull(stack))
            {
                return;
            }
            stack.array[++stack.top] = item;
        }
        int Pop(Stack stack)
        {
            if (IsEmpty(stack))
            {
                return int.MinValue;
            }
            return stack.array[stack.top--];
        }
        void MoveDisksBetweenTwoPoles(Stack source, Stack destination, char s, char d)
        {
            int pole1TopDisk = Pop(source);
            int pole2TopDisk = Pop(destination);

            // When pole1 is empty
            if (pole1TopDisk == int.MinValue)
            {
                Push(source, pole2TopDisk);
                MoveDisk(d, s, pole2TopDisk);
            }
            // When pole2 is empty
            else if (pole2TopDisk == int.MinValue)
            {
                Push(destination, pole1TopDisk);
                MoveDisk(s, d, pole1TopDisk);
            }
            // When top disk of pole1 > top disk of pole2
            else if (pole1TopDisk > pole2TopDisk)
            {
                Push(source, pole1TopDisk);
                Push(source, pole2TopDisk);
                MoveDisk(d, s, pole2TopDisk);
            }
            // When top disk of pole1 < top disk of pole2
            else
            {
                Push(destination, pole2TopDisk);
                Push(destination, pole1TopDisk);
                MoveDisk(s, d, pole1TopDisk);
            }
        }
        void MoveDisk(char fromPeg, char toPeg, int disk)
        {
            Console.WriteLine("Move the disk " + disk + " from " + fromPeg + " to " + toPeg);
        }

        // Function to implement TOH Puzzle
        void IterativeHanoi(int numOfDisks, Stack source, Stack auxilliary, Stack destination)
        {
            int i, totalNumOfMoves;
            char s = 'S', d = 'D', a = 'A';

            if (numOfDisks % 2 == 0)
            {
                char temp = d;
                d = a;
                a = temp;
            }
            totalNumOfMoves = (int)(Math.Pow(2, numOfDisks) - 1);

            for (i = numOfDisks; i >= 1; i--)
            {
                Push(source, i);
            }
            for (i = 1; i <= totalNumOfMoves; i++)
            {
                if (i % 3 == 1)
                {
                    MoveDisksBetweenTwoPoles(source, destination, s, d);
                }
                else if (i % 3 == 2)
                {
                    MoveDisksBetweenTwoPoles(source, auxilliary, s, a);
                }
                else if (i % 3 == 0)
                {
                    MoveDisksBetweenTwoPoles(auxilliary, destination, a, d);
                }
            }
        }
        #endregion

        #region Tower Of Hanoi Recursive Solution
        void RecuriveHanoi(int numOfDisks, char sourcePole, char destinationPole, char auxilliaryPole)
        {
            if (numOfDisks == 0)
            {
                return;
            }
            RecuriveHanoi(numOfDisks - 1, sourcePole, auxilliaryPole, destinationPole);
            Console.WriteLine("Move the disk ({0}) from {1} to {2}", numOfDisks, sourcePole, destinationPole);
            RecuriveHanoi(numOfDisks - 1, auxilliaryPole, destinationPole, destinationPole);
        }
        #endregion
        static void Main(string[] args)
        {
            Program program = new Program();
            int numOfDisks = 3;
            Stack source, destination, auxilliary;

            source = program.CreateStack(numOfDisks);
            auxilliary = program.CreateStack(numOfDisks);
            destination = program.CreateStack(numOfDisks);
            // Iterative Hanoi
            Console.WriteLine("Iterative Hanoi");
            program.IterativeHanoi(numOfDisks, source, auxilliary, destination);

            // Recursive Hanoi
            Console.WriteLine("Recursive Hanoi");
            char src = 'A', dest = 'C', aux = 'B';
            program.RecuriveHanoi(numOfDisks, src, dest, aux);

            Console.ReadKey();
        }
    }
}