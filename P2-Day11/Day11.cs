using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Program
    {
        public bool doorState;
        public int doorId;
        public Program() // Default constructor
        {
        }
        static void Main(string[] args)
        {
            commandLineOperation("writereverse salih acr 170508026");
            
            for (int i = 0; i < 20; i++)
            {
                doorsAndKeysPuzzle();
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
        /*
            This function writes the given text in reverse order.
        */
        static void commandLineOperation(string cmd)
        {
            string[] words = cmd.Split(' ');
            string result = "";
            if (words[0] == "writereverse")
            {
                for (int i = words.Length - 1; i > 0; i--)
                {
                    result += words[i] + " ";
                }
            }
            else
            {
                Console.WriteLine($"'{words[0]}' is not recognized as an"
                + "internal or external command,operable program or batch file.");
            }
            Console.WriteLine(result);
        }
        /*
            This function solves the , hotel doors and keycode algorithm.
        */
        static void doorsAndKeysPuzzle()
        {

            int doorSize = 100;
            int keySize = 20;

            var doorArray = new Program[doorSize];

            for (int i = 0; i < doorArray.Length; i++)
            {
                doorArray[i] = new Program();
                doorArray[i].doorId = i + 1;
                doorArray[i].doorState = false;
            }

            int[] keyArray = new int[keySize];
            for (int i = 0; i < keyArray.Length; i++)
            {
                keyArray[i] = i + 1;
            }
            
            for(int i = 0; i < keyArray.Length; i++){
                for(int j = 0; j < doorArray.Length; j++){
                    if(doorArray[j].doorId % keyArray[i] == 0){
                        if(doorArray[j].doorState == false){
                            doorArray[j].doorState = true;
                            //Console.WriteLine(doorArray[j].doorId + " was opened.");
                        }
                        else{
                            doorArray[j].doorState = false;
                            //Console.WriteLine(doorArray[j].doorId + " was closed.");
                        }
                    }
                }
            }
            for(int i = 0; i < doorArray.Length; i++){
              if(doorArray[i].doorState == true){
                  Console.Write(doorArray[i].doorId+ " ");
              }
            }
        }
    }
}
