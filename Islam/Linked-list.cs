

/* my notions
1- This code do some actions on the linked list like " add nums in the first node , and add nums in the last node , and delete from first and last .
2- i solved the the convert the linked list to an array with help from net , but now i understand the code and how its works. 
3- the linked list better than the array " - its unfixed - easy to add and delet the elemants , we dont need to take a places in memory secuetially.
4- to convert an linked list to an array we need to detemind the length of the linked list and copy the data to the array .*/


using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int Value)
    {
        Data = Value;
        Next = null;
    }
}

class LinkedList
{
    private Node Head;

    public LinkedList()
    {
        Head = null;
    }

    public void AddFirst(int Value)
    {
        Node NewNode = new Node(Value);
        NewNode.Next = Head;
        Head = NewNode;
    }

    public void RemoveFirst()
    {
        if (Head != null)
        {
            Head = Head.Next;
        }
    }

    public void RemoveLast()
    {
        if (Head == null || Head.Next == null)
        {
            Head = null;
            return;
        }

        Node current = Head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public void Display()
    {
        Node current = Head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public int[] ToArray()
    {
        int size = GetSize();
        int[] array = new int[size];
        Node current = Head;
        int index = 0;

        while (current != null)
        {
            array[index] = current.Data;
            current = current.Next;
            index++;
        }

        return array;
    }

    private int GetSize()
    {
        int size = 0;
        Node current = Head;
        while (current != null)
        {
            size++;
            current = current.Next;
        }
        return size;
    }
}

class Program
{
    static void Main()
    {
        LinkedList myLinkedList = new LinkedList();
        myLinkedList.AddFirst(4);
        myLinkedList.AddFirst(3);
        myLinkedList.AddFirst(3);
        myLinkedList.AddFirst(12);
        myLinkedList.Display();
 System.Console.WriteLine("after remove from first");
        myLinkedList.RemoveFirst();

        myLinkedList.Display();
       
  System.Console.WriteLine("after remove from last");
        myLinkedList.RemoveLast();

        myLinkedList.Display();
       
System.Console.WriteLine("as array");
       int[] array = myLinkedList.ToArray();
        foreach (int item in array)
        {
            Console.WriteLine(item);
        }
        }
    }



