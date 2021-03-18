using System;

namespace DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            Singleton nesne1 = Singleton.NesneVer();
            Singleton nesne2 = Singleton.NesneVer();

            if (nesne1 == nesne2)
            {
                Console.WriteLine("test1");
            }
            if (nesne1.Equals(nesne2))
            {
                Console.WriteLine("test2");
            }
            if (nesne1.GetHashCode() == nesne2.GetHashCode())
            {
                Console.WriteLine("test3");
            }
            Console.ReadKey();
        }
    }
    class Singleton
    {
        private Singleton()
        {

        }
        private static Singleton nesne;
        public static Singleton NesneVer()
        {
            if (nesne == null)
            {
                nesne = new Singleton();
            }
            return nesne;
        }
    }
}
