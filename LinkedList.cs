using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node
    {
        public Node nextnode;
        public int data;
        public Node()
        {
            nextnode = null;
            data = -1;
        }
        public Node(int data)
        {
            nextnode = null;
            this.data = data;
        }
    }
    class LinkedList
    {
        private Node header;
        public LinkedList()
        {
            header = new Node();
        }
        public void Add(int x)
        {
            if (header.nextnode == null)
            {
                Node p = new Node(x);
                header.nextnode = p;
                p.nextnode = header;
            }
            else
            {
                Node p = header.nextnode;
                while (p.nextnode != header)
                {
                    p = p.nextnode;
                }
                Node q = new Node(x);
                p.nextnode = q;
                q.nextnode = header;
            }
        }

        public void Print()
        {
            Node p = header.nextnode;
            while (p != header)
            {
                Console.Write(p.data + ",");
                p = p.nextnode;
            }
        }

        public void DeleteOdd()
        {
            Node p = header.nextnode;
            Node q = header;
            bool odd;
            odd = true;
            while (p != header)
            {
                for (int i = 2; i <= p.data / 2; i++)
                {

                    if (p.data % i == 0)
                    {
                        odd = false;
                        break;
                    }
                    else
                        odd = true;
                }

                if (!odd)
                {
                
                      q = p;
                }
                else
                {    
                    q.nextnode = p.nextnode;
                }

                p = p.nextnode;
            }
        }
        public LinkedList Merge(LinkedList list1, LinkedList list2)
        {
            LinkedList c = new LinkedList();
            Node p = list1.header.nextnode;
            Node q = list2.header.nextnode;
            Node z = c.header.nextnode; ;
            while (p != null && q != null)
            {
                if (p.data <= q.data)
                {
                    z.nextnode = p;
                    z = p;
                    p = p.nextnode;
                }
                else
                {
                    z.nextnode = q;
                    z = q;
                    q = q.nextnode;
                }

            }
            if (p != null)
            {
                z.nextnode = p;
            }
            else
                z.nextnode = q;
            return c;
        }
    }
    class LQuene
    {
        Node front;
        Node rear;
        public LQuene()
        {
            front = new Node();
            rear = new Node();
        }
        public void Add(int x)
        {
            Node p = new Node(x);
            if (front == null)
            {
                front = p;
                rear = p;
            }
            else
            {
                rear.nextnode = p;
                rear = p;
            }

        }
        public int Delete()
        {
            int x = 0;
            if (front == null)
            {
                Console.WriteLine("Quene is empty");
                return -100000;
            }
            else
            {
                x = front.data;
                front = front.nextnode;
                return x;
            }
        }
    }
    class LStack
    {
        Node top;
        public LStack()
        {
            top = new Node();
        }
        public void Add(int x)
        {
            Node p = new Node(x);
            top.nextnode = p;
            top = p;
        }
        public int Delete()
        {
            int x = 0;
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return -100000;
            }
            else
            {
                x = top.data;
                top = top.nextnode;
                return x;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            LinkedList mergelist = new LinkedList();
            LStack stack = new LStack();
            LQuene queue = new LQuene();
            while (true)
            {
                Console.WriteLine("chose ");
                Console.WriteLine("1:build linkliste");
                Console.WriteLine("2:print");
                Console.WriteLine("3:delete the odd numbers");
                Console.WriteLine("4:merge two list");
                Console.WriteLine("5:push a node in stack");
                Console.WriteLine("6:pop a node of stack");
                Console.WriteLine("7:push a node in queue");
                Console.WriteLine("8:push a node of queue");
                Console.WriteLine("9:exst");
                int key;
                key = Convert.ToInt32(Console.ReadLine());
                if (key == 9)
                    break;
                else if (key == 1)
                {
                    Console.WriteLine("enter number of node");
                    int n = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {

                        Console.WriteLine("enter data of node");
                        int s = Convert.ToInt32(Console.ReadLine());
                        list.Add(s);
                    }
                }
                else if (key == 2)
                {
                    list.Print();
                }
                else if (key == 3)
                {
                    list.DeleteOdd();
                }
                else if (key == 4)
                {
                    Console.WriteLine("enter number of node list 1");
                    LinkedList list1 = new LinkedList();
                    int n = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("enter data of node");
                        int s = Convert.ToInt32(Console.ReadLine());
                        list1.Add(s);
                    }
                    Console.WriteLine("enter number of node list 2");
                    LinkedList list2 = new LinkedList();
                    int b = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < b; i++)
                    {
                        Console.WriteLine("enter data of node");
                        int s = Convert.ToInt32(Console.ReadLine());
                        list2.Add(s);
                    }
                    mergelist.Merge(list1, list2);
                }
                else if (key == 5)
                {
                    Console.WriteLine("enter data of node");
                    int s = Convert.ToInt32(Console.ReadLine());
                    stack.Add(s);
                }
                else if (key == 6)
                {
                    Console.WriteLine("the node with :" + stack.Delete() + "was deleteed");
                }
                else if (key == 7)
                {
                    Console.WriteLine("enter data of node");
                    int s = Convert.ToInt32(Console.ReadLine());
                    queue.Add(s);
                }
                else if (key == 8)
                {
                    Console.WriteLine("the node with :" + queue.Delete() + "was deleteed");
                }
            }

        }
    }
}
