using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        QueueNode<T> headNode, lastNode;
        public int Length = 0;
        public Queue()
        {
            headNode = null;
            lastNode = null;
        }
        bool IsEmpty()
        {
            return headNode == null;
        }
        public T Push(T data)
        {
            QueueNode<T> addedNode = new QueueNode<T>(data);
            if (IsEmpty())
            {
                headNode = lastNode = addedNode;
            }
            else
            {
                lastNode.next = addedNode;
                lastNode = addedNode;
            }
            Length++;
            return addedNode.data;
        }
        public T Find(T data)
        {
            QueueNode<T> iter = headNode;
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
        public void Pop()
        {
            if (IsEmpty())
            {
                throw new ArgumentNullException("Not found");
                return;
            }
            else
            {
                headNode = headNode.next;
            }
            Length--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            QueueNode<T> iter = headNode;

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