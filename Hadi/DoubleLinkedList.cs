using System;
namespace DoubleLinked_List
{
    internal class DoubleLinkedList<T>
    {
        public int Count { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void Display()
        {
            int index = 1;
            var node = Head;
            while (index != Count + 1)
            {
                Console.WriteLine("node {0} : {1}", index, node.Data.ToString());
                node = node.Next;
                index++;
            }
        }

        public void AddFirst(Node<T> node)
        {
            var TempNode = Head;
            Head = node;
            Head.Next = TempNode;
            Count++;
            if (Count == 1)
            {
                Tail = TempNode;
            }
            else
            {
                TempNode.Previous = Head;
            }
        }
        public void AddLast(Node<T> node)
        {

            if (Count == 0)
            {
                Head = node;
            }
            if (Count > 0)
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }
        //7. Write a program in C to delete a node from the beginning of a doubly linked list.
        public void RemoveFrist()
        {
            if (Count == 1)
            {
                Clear();
            }
            if (Count > 1)
            {
                Head = Head.Next;
                Head.Previous = null;
                Count--;
            }
        }

        //8.Write a program in C to delete a node from the last node of a doubly linked list. 
        public void RemoveLast()
        {
            if (Count == 1)
            {
                Clear();
            }
            if (Count > 1)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                Count--;
            }
        }

        public bool Contains(T item)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Data.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        private void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

    }
}
