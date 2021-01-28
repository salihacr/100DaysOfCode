using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
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

            LinkedList<Student> studentList = new LinkedList<Student>();

            studentList.AddLast(s1);
            studentList.AddLast(s2);
            studentList.AddLast(s3);
            studentList.AddLast(s4);
            studentList.AddLast(s5);
            studentList.AddLast(s6);
            studentList.AddLast(s7);

            studentList.PrintList(studentList);

            Console.WriteLine("---------------------------------------");
            Student updated = studentList.Find(s5);

            updated.favouriteLesson = "Deep Learning (Updated)";

            studentList.PrintList(studentList);
            Console.WriteLine("---------------------------------------");

            Student deleted = studentList.BinarySearch(studentList, 13);

            Console.WriteLine(deleted.id + " " + deleted.name + " " + deleted.surname);
            Console.WriteLine("---------------------------------------");
            studentList.Remove(deleted);
            studentList.PrintList(studentList);

            Console.WriteLine("---------------------------------------");


            Console.ReadKey();
        }
    }
}
