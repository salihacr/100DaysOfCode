using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        StackNode<T> headNode;
        public int Length = 0;
        public Stack()
        {
            headNode = null;
        }
        bool IsEmpty()
        {
            return headNode == null;
        }
        public void Push(T data)
        {
            StackNode<T> addedNode = new StackNode<T>(data);

            if (headNode == null)
            {
                headNode = addedNode;
            }
            else
            {
                addedNode.next = headNode;
                headNode = addedNode;
            }
            Length++;
        }
        public void Pop()
        {
            if (IsEmpty())
            {
                return;
            }
            else
            {
                headNode = headNode.next;
            }
            Length--;

        }

        public T Find(T data)
        {
            StackNode<T> iter = headNode;
            while (iter != null)
            {
                if (iter.data.Equals(data))
                {
                    return iter.data;
                }
                iter = iter.next;
            }
            return default(T);
        }
        public T Top()
        {
            if (!IsEmpty())
            {
                return headNode.data;
            }
            else
            {
                return default(T);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            StackNode<T> iter = headNode;

            while (iter != null)
            {
                yield return iter.data;
                iter = iter.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
