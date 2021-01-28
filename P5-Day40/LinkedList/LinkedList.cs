using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
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
    class LinkedList<T> : LinkedListBase<T>
    {
        public LinkedList<Student> Sort(LinkedList<Student> list)
        {
            Node<Student> iter = list.headNode;
            Node<Student> firstVal = null;
            Student val = null;
            while (iter != null)
            {
                firstVal = iter.next;
                while (firstVal != null)
                {
                    if (iter.data.id > firstVal.data.id)
                    {
                        val = firstVal.data;
                        firstVal.data = iter.data;
                        iter.data = val;
                    }
                    firstVal = firstVal.next;
                }
                iter = iter.next;
            }
            return list;
        }
        public Student BinarySearch(LinkedList<Student> list, int searchedElement)
        {
            Sort(list);
            int firstIndex = 0;
            int lastIndex = list.Length - 1;
            bool found = false;
            while (firstIndex <= lastIndex)
            {
                int middleIndex = (lastIndex + firstIndex) / 2;

                if (list.Get(middleIndex).id == searchedElement)
                {
                    found = true;
                    Console.WriteLine("The searched element (" + searchedElement + ") was found.");
                    return list.Get(middleIndex);
                }
                else if (searchedElement < list.Get(middleIndex).id)
                {
                    lastIndex = middleIndex - 1;
                }
                else
                {
                    firstIndex = middleIndex + 1;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Not Found");
            }
            return null;
        }
        public void PrintList(LinkedList<Student> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine("ID: " + item.id + " Name Surname: " + item.name + " " + item.surname + " Favorite Lesson: " + item.favouriteLesson);
            }
        }
    }
}
