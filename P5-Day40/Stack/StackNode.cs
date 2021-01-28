using System;

namespace Stack
{
    public class StackNode<T>
    {
        public T data { get; set; }
        public StackNode<T> next;

        public StackNode(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
