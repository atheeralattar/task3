using System;

public class Nodaya
{
    public int Data { get; set; }
    public Nodaya Next { get; set; }
    public Nodaya Previous { get; set; }
}

public class DoublyLinkedList
{
    public Nodaya Head { get; set; }

    public void CreateList(int noOfNodayas)
    {
        Nodaya temp = null;

        for (int i = 1; i <= noOfNodayas; i++)
        {
            Console.Write("\nInput data for nodaya {0}: ", i);
            int data = int.Parse(Console.ReadLine());

            Nodaya newNodaya = new Nodaya { Data = data };

            if (Head == null)
            {
                Head = newNodaya;
                temp = newNodaya;
            }
            else
            {
                temp.Next = newNodaya;
                newNodaya.Previous = temp;
                temp = newNodaya;
            }
        }
    }

    public void InsertNodayaAtPosition(int data, int position)
    {
        Nodaya temp = Head;
        Nodaya newNode = new Nodaya { Data = data };

        for (int i = 1; temp != null && i < position - 1; i++)
        {
            temp = temp.Next;
        }

        if (temp != null)
        {
            newNode.Next = temp.Next;
            newNode.Previous = temp;

            if (temp.Next != null)
            {
                temp.Next.Previous = newNode;
            }

            temp.Next = newNode;
        }
    }

    public void InsertNodayaAtMiddle(int data)
    {
        Nodaya newNode = new Nodaya { Data = data };
        Nodaya slow_ptr = Head;
        Nodaya fast_ptr = Head;

        while (fast_ptr.Next != null && fast_ptr.Next.Next != null)
        {
            slow_ptr = slow_ptr.Next;
            fast_ptr = fast_ptr.Next.Next;
        }

        newNode.Next = slow_ptr.Next;
        newNode.Previous = slow_ptr;
        slow_ptr.Next = newNode;
        if (newNode.Next != null)
        {
            newNode.Next.Previous = newNode;
        }
    }

    public void DisplayList()
    {
        Nodaya temp = Head;
        int n = 1;

        Console.WriteLine("\n\nAfter operation, the new list is: \n");

        while (temp != null)
        {
            Console.WriteLine("Nodaya {0} : {1}", n, temp.Data);
            n++;
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();

        Console.Write("Input the number of nodayas (3 or more): ");
        int noOfNodayas = int.Parse(Console.ReadLine());

        list.CreateList(noOfNodayas);

        Console.Write("\nChoose operation (1: Insert at Position, 2: Insert at Middle): ");
        int operation = int.Parse(Console.ReadLine());

        if (operation == 1)
        {
            Console.Write("\nInput the position to insert a new nodaya: ");
            int position = int.Parse(Console.ReadLine());

            Console.Write("Input data for the new nodaya to be inserted: ");
            int data = int.Parse(Console.ReadLine());

            list.InsertNodayaAtPosition(data, position);
        }
        else if (operation == 2)
        {
            Console.Write("\nInput data for the new nodaya to be inserted in the middle: ");
            int data = int.Parse(Console.ReadLine());

            list.InsertNodayaAtMiddle(data);
        }
        else
        {
            Console.WriteLine("Invalid operation choice!");
            return;
        }

        list.DisplayList();
    }
}
