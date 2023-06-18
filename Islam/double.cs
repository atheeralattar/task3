using System;

public class Node1
{
    public int Data;
    public Node1 Previous;
    public Node1 Next;

    public Node1(int data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}

public class Dlinked
{
    public Node1 head;

    public Dlinked()
    {
        head = null;
    }

    public void Insert(int data)
    {
        Node1 newNode = new Node1(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
    }

    public void Display()
    {
        Node1 current = head;

        while (current != null)
        {
            string dataString = current.Data.ToString();
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
}

public class action 
{
    static int large(Node1 head)
    {
        if (head == null)
        {
            return 0;
        }

        int largestNumber = head.Data;
        Node1 current = head.Next;

        while (current != null)
        {
            if (current.Data > largestNumber)
            {
                largestNumber = current.Data;
            }
            current = current.Next;
        }

        return largestNumber;
    }

    public static void Main(string[] args)
    {
        Dlinked my = new Dlinked();
        my.Insert(1);
        my.Insert(3);
        my.Display();

        int largest = large(my.head);
        Console.WriteLine("the large num is " + largest + "the nums displayed as String");
        
    }
}
