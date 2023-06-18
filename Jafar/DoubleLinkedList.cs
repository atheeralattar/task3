namespace DoubleLinkedList;
public class Node
{
    public string Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }
    public Node(string data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }

}

public class DoubleLinkedListt
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    public static int Count { get; set; }



    public void AddFirst(string data)
    {
        var newNode = new Node(data);
        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
            Count++;
        }
        else
        {
            var currentHead = Head;
            Head = newNode;
            Head.Next = currentHead;
            currentHead.Prev = Head;
            Count++;
        }
    }
    public void AddLast(string data)
    {
        var newNode = new Node(data);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
            Count++;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            Count++;
        }
    }
    public void Print()
    {

        Node? currentHead = Head;
        while (currentHead != null)
        {
            if (currentHead.Next == null)
            {
                Console.Write(currentHead.Data);
                break;
            }

            Console.Write(currentHead.Data + " <--> ");
            currentHead = currentHead.Next;

        }

        Console.WriteLine();
        Console.WriteLine("LinkedList Size: " + Count);
    }

    public void DeleteFirst()
    {
        if (Count == 0)
        {
            Console.WriteLine("Empty Linked List");
        }
        else if (Count == 1)
        {
            Head = null;
            Tail = null;
            Count--;
        }
        else
        {

            Head = Head.Next;
            Head.Prev = null;
            Count--;
        }

    }

    public void DeleteLast()
    {
        if (Count == 0)
        {
            Console.WriteLine("Empty Linked List");
        }
        else if (Count == 1)
        {
            Head = null;
            Tail = null;
            Count--;
        }
        else
        {
            Tail = Tail.Prev;
            Tail.Next = null;
            Count--;
        }
    }
    public string DeleteAt(int index)
    {
        if (Count == 0)
        {
            return "Empty Linked List";
        }

        if (index < 0 || index > Count - 1)
        {
            return "index out of range";
        }

        var currentIndex = 0;
        var currentNode = Head;
        while (currentNode != null)
        {
            
            if (index == 0)
            {
                DeleteFirst();
                break;

            }
            if (index == Count - 1)
            {
                DeleteLast();
                break;
            }
            if (currentIndex == index)
            {
                var nextNode = currentNode.Next;
                var prevNode = currentNode.Prev;
                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;
                Count--;
                return $"element ({currentNode.Data}) deleted";
            }
            currentNode = currentNode.Next;
            currentIndex++;
        }

        return "Element not found";
    }

    public void Q9()
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
        Console.Write($"Enter the index of node to delete({0} - {numberOfNodes - 1}): ");
        var index = Convert.ToInt32(Console.ReadLine());
        DeleteAt(index);
        Console.WriteLine("\nLinked List after delete:");
        Print();
    }

    public void Q10()
    {
        Console.Write("Enter the number of nodes (3 or more ): ");
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
        DeleteAt(Count/2);
        Console.WriteLine("\nLinked List after delete the middle:");
        Print();
    }
}
// 1 <--> 2 <--> 3 <--> 4
