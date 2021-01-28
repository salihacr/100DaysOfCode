using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string favouriteLesson { get; set; }

        public Student(int id, string name, string surname, string favouriteLesson)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.favouriteLesson = favouriteLesson;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(26, "Salih", "Bey", "Data Structures");
            Student s2 = new Student(20, "Harun", "Bey", "Algorithms");
            Student s3 = new Student(13, "Hikmet", "Bey", "Evolutionary Computation");
            Student s4 = new Student(3, "İbrahim", "Bey", "Automata");
            Student s5 = new Student(46, "Test", "Bey", "Discrete Math");
            Student s6 = new Student(34, "Deneme", "Bey", "Mobile Programming");
            Student s7 = new Student(7, "Admin", "Bey", "Operating Systems");

            Queue<Student> queue = new Queue<Student>();

            queue.Push(s1);
            queue.Push(s2);
            queue.Push(s3);
            queue.Push(s4);
            queue.Push(s5);
            queue.Push(s6);
            queue.Push(s7);

            foreach (var student in queue)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");
            Student updated = queue.Find(s3);
            updated.favouriteLesson = "Automata Theory (Update)";
            foreach (var student in queue)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");

            queue.Pop();
            queue.Pop();
            foreach (var student in queue)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");

            Console.ReadKey();
        }
    }
}
