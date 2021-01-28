using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListBase<T> : IEnumerable<T>
    {
        public int Length { get; set; }
        public Node<T> headNode;
        public T AddFirst(T data)
        {
            Node<T> addedNode = new Node<T>(data);
            addedNode.next = headNode;
            headNode = addedNode;
            Length++;

            return addedNode.data;
        }
        public T AddLast(T data)
        {
            Node<T> addedNode = new Node<T>(data);
            if (headNode == null)
            {
                AddFirst(data);
                Length--;
            }
            else
            {
                Node<T> iter = headNode;
                while (iter.next != null)
                {
                    iter = iter.next;
                }
                iter.next = addedNode;
                Length++;

            }
            return addedNode.data;
        }
        public T AddAfter(int index, T data)
        {
            Node<T> addedNode = new Node<T>(data);
            Node<T> iter = headNode;

            if (headNode == null)
            {
                AddFirst(data);
                Length--;
            }
            // add first index
            if (index == 0 && headNode != null)
            {
                addedNode.next = headNode;
                headNode = addedNode;
            }
            Node<T> previousNode = null;
            int i = 0;
            while (i < index)
            {
                previousNode = iter;
                iter = iter.next;
                if (iter == null)
                {
                    break;
                }
                i++;
            }
            addedNode.next = iter;
            previousNode.next = addedNode;

            Length++;
            return addedNode.data;
        }
        public void RemoveFirst()
        {
            Node<T> iter = headNode;
            if (iter != null)
            {
                headNode = iter.next;
            }
            Length--;
        }
        public void RemoveLast()
        {
            Node<T> deletedNode = headNode;
            while (deletedNode.next.next != null)
            {
                deletedNode = deletedNode.next;
            }
            deletedNode.next = null;
            Length--;
        }
        public void Remove(T data)
        {
            Node<T> iter = headNode;
            Node<T> previousNode = null;

            if (iter != null && iter.data.Equals(data))
            {
                headNode = iter.next;
            }
            while (iter != null && !iter.data.Equals(data))
            {
                previousNode = iter;
                iter = iter.next;
            }
            if (iter == null)
            {
                throw new ArgumentNullException("Data Not Found");
            }
            previousNode.next = iter.next;
        }
        public T Find(T data)
        {
            Node<T> iter = headNode;
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
        public int GetIndex(T data)
        {
            Node<T> iter = headNode;
            int i = 0;
            while (iter != null)
            {
                if (iter.data.Equals(data))
                {
                    return i;
                }
                iter = iter.next;
                i++;
            }
            return -1;
        }
        public bool Contains(T data)
        {
            return GetIndex(data) != -1;
        }
        public T Get(int index)
        {
            if (index < 0 || index > this.Length)
            {
                throw new IndexOutOfRangeException("Index not available");
            }
            if (index == 0)
            {
                return headNode.data;
            }
            int i = 0;
            Node<T> iter = headNode;
            while (i <= index)
            {
                if (i == index)
                {
                    return iter.data;
                }
                else
                {
                    iter = iter.next;
                    i++;
                }
            }
            return default(T);
        }
        public void Clear()
        {
            headNode = null;
            Length = 0;
        }
        public int GetLength()
        {
            return this.Length;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> iter = headNode;

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
