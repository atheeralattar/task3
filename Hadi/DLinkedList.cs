    internal class DLinkedList<T>
    {   //this is for all Questions
        public int Count { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        //1-Write a program in C to create and display a doubly linked list. 
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
        //2-Write a program in C to create a doubly linked list and display it in reverse order.  
        public void DisplayReverse()
        {
            int index = 1;
            var node = Tail;
            while (index != Count + 1)
            {
                Console.WriteLine("node {0} : {1}", index, node.Data.ToString());
                node = node.Previous;
                index++;
            }
        }
        //3. Write a program in C to insert a node at the beginning of a doubly linked list. 
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
        //4. Write a program in C to insert a new node at the end of a doubly linked list. 
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
        // 5. Write a program in C to insert a new node at any position in a doubly linked list. 
        public void InsertAt(Node<T> node, int Position)
        {
            if (Count + 1 == Position)
            {
                AddLast(node);
                return;
            }
            if (Position == 1)
            {
                AddFirst(node);
                return;
            }
            int index;
            if (Position <= Count / 2)
            {
                index = 1;
                var node1 = Head;
                while (index != Position - 1)
                {
                    node1 = node1.Next;
                    index++;
                }

                var TempNode = node1.Next;
                node1.Next = node;
                node.Previous = node1;
                TempNode.Previous = node;
                node.Next = TempNode;
                if (index == 1)
                {
                    Head = node1;
                }
            }
            if (Position > Count / 2)
            {
                index = Count;
                var node1 = Tail;
                while (index != Position)
                {
                    node1 = node1.Previous;
                    index--;
                }
                var TempNode = node1.Previous;
                node.Next = node1;
                node.Previous = TempNode;
                node1.Previous = node;
                TempNode.Next = node;
            }
            Count++;
        }
        //6. Write a program in C to insert a new node in the middle of a doubly linked list. 
        public void InsertAtMiddle(Node<T> node)
        {
            InsertAt(node, (Count / 2) + 1);
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

        //9. Write a program in C to delete a node from any position in a doubly linked list.
        public void RemoveAt(int Position)
        {
            if (Count == Position)
            {
                RemoveLast();
                return;
            }
            if (Position == 1)
            {
                RemoveFrist();
                return;
            }
            int index;
            if (Position <= Count / 2)
            {
                index = 1;
                var node1 = Head;
                while (index  != Position)
                {
                    node1 = node1.Next;
                    index++;
                }
                var temp1 = node1.Next;
                var temp2 = node1.Previous;
                node1 = null;
                temp1.Previous = temp2;
                temp2.Next = temp1;
            }
            if (Position > Count / 2)
            {
                index = Count;
                var node1 = Tail;
                while (index != Position)
                {
                    node1 = node1.Previous;
                    index--;
                }
                var temp1 = node1.Next;
                var temp2 = node1.Previous;
                node1 = null;
                temp1.Previous = temp2;
                temp2.Next= temp1;
            }
            Count--;
        }

        //10. Write a program in C to delete a node from the middle of a doubly linked list. 
        public void RemoveAtMiddle(Node<T> node)
        {
            RemoveAt((Count / 2) + 1);
        }

        //11. Write a program in C to find the maximum value in a doubly linked list. 
        public int MaxValue()
        {
            var node = Head;
            int tempvalue = 0;
            while (node != null)
            {
                if (Convert.ToInt32(node.Data) > tempvalue)
                {
                    tempvalue = Convert.ToInt32(node.Data);
                }
                node = node.Next;
            }
            return tempvalue;
        }
        //12.Write a C program to convert a Doubly Linked list into a string. 
        public string toString()
        {
            var node = Head;
            string String = null;
            while (node != null)
            {
                String += Convert.ToString(node.Data);
                node = node.Next;
            }
            return String;
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
