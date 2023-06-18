namespace ConsoleApp2;

    public class CircularLinkedList
    {
        public Node Head { get; set; }
        public int Count { get; set; }

        public void AddFirst(string data)
        {
            var newNode = new Node(data);
            if (Count == 0)
            {
                Head = newNode;
                Head.Next = Head;
                Count++;
            }
            else
            {
                var currentHead = Head;
                newNode.Next = Head;
                currentHead.Next = newNode;
                Head = newNode;
                Count++;
            }
        }

        public void AddLast(string data)
        {
            var newNode = new Node(data);
            if (Count == 0)
            {
                Head = newNode;
                Head.Next = Head;
                Count++;
            }
            else
            {
                var currentNode = Head;
                while (currentNode.Next != Head)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
                newNode.Next = Head;
                Count++;
            }

    }

    public void AddAt(int index, string data)
        {
            if (index < 0 || index > Count - 1)
            {
                Console.WriteLine("index out of range");
                 return;
            }
    
        if (index == 0)
        {
            AddFirst(data);
        }
        else if (index == Count - 1)
        {
            AddLast(data);
        }
        else
        {
            var currentNode = Head;
            var newNode = new Node(data);
            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }

    }
        public void Print()
        {
            Node current = Head;
            while (current.Next != Head)
            {
                Console.Write(current.Data + " --> ");
                current = current.Next;
            }

            Console.WriteLine(current.Data);
        }

        public void Q4()
        {
            Console.Write("Enter the number of nodes: ");
            var numberOfNodes = Convert.ToInt32(Console.ReadLine());
            var nodes = new string[numberOfNodes];
            for (var i = 0; i < numberOfNodes; i++)
            {
                Console.Write($"\nEnter node {i + 1} data: ");
                nodes[i] = Console.ReadLine();
                AddLast(nodes[i]);
            }

            Console.WriteLine("Linked List are:");
            Print();
            Console.Write($"Enter the position to insert a new node({0} - {numberOfNodes - 1}): ");
            var index = Convert.ToInt32(Console.ReadLine());
            Console.Write($"data for the position {index}: ");
    var data = Console.ReadLine();
        AddAt(index,data);
            Console.WriteLine("\nLinked List after addition:");
            Print();

    }
}

