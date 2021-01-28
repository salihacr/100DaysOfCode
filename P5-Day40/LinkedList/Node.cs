using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
