using System;
namespace Stack
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

            Stack<Student> stack = new Stack<Student>();

            stack.Push(s1);
            stack.Push(s2);
            stack.Push(s3);
            stack.Push(s4);
            stack.Push(s5);
            stack.Push(s6);
            stack.Push(s7);

            foreach (var student in stack)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Top Element : " + stack.Top().name + " " + stack.Top().surname);
            Console.WriteLine("Length of Stack : " + stack.Length);
            Console.WriteLine("--------------------------------");
            Student updated = stack.Find(s4);
            updated.favouriteLesson = "Automata Theory (Update)";
            foreach (var student in stack)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");

            stack.Pop();
            stack.Pop();
            foreach (var student in stack)
            {
                Console.WriteLine("ID: " + student.id + " Name Surname: " + student.name + " " + student.surname + " Favorite Lesson: " + student.favouriteLesson);
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Top Element : " + stack.Top().name + " " + stack.Top().surname);
            Console.WriteLine("Length of Stack : " + stack.Length);
            Console.WriteLine("--------------------------------");

            Console.ReadKey();
        }
    }
}
