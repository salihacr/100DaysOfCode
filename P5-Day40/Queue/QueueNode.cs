using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueNode<T>
    {
        public T data { get; set; }
        public QueueNode<T> next;

        public QueueNode(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
