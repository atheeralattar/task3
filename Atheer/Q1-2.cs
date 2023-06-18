using System;
using System.Runtime.Remoting.Messaging;

namespace Classes
{
    public class linkedListNode
    {
        public int Data;
        public linkedListNode Next;
        public linkedListNode Prev;

        public linkedListNode(int x)
        {
            this.Data = x;
            this.Next = null;
            this.Prev = null;

        }


    }

    public class LinkedList
    {
        
        public linkedListNode head;
        public linkedListNode tail;
        public int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddNodeToFront(int data)
        {
            linkedListNode node = new linkedListNode(data);
            if (head == null)
            {
                head = node;
                tail = node;

            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            
            
        }

        public void PrintList()
        {
            linkedListNode runner = head;
            while (runner != null)
            {
                if (runner.Prev == null)
                {
                    Console.WriteLine("This is the list head: {0}", runner.Data);

                }
                else if (runner.Next == null)
                {
                    Console.WriteLine("This is the list tail: {0}", runner.Data);
                    break;
                }
                else
                {
                    Console.WriteLine("This is an in between node: {0}", runner.Data);
                }

                runner = runner.Next;
            }
        }


        public void PrintListReversed()
        {
            linkedListNode runner = tail;
            while (runner != null)
            {
                if (runner.Prev == null)
                {
                    Console.WriteLine("This is the list head: {0}", runner.Data);
                    break;
                    
                }
                
                else
                {
                    Console.WriteLine("This is an in between node: {0}", runner.Data);
                    runner = runner.Prev;
                }

                
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {

            var list = new LinkedList();
            list.AddNodeToFront(8);
            list.AddNodeToFront(5);
            list.AddNodeToFront(2);
            Console.WriteLine("Normal list");
            list.PrintList();
            Console.WriteLine("Reversed list");
            list.PrintListReversed();

        }
        
    }
}