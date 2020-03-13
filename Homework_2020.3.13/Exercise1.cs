using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class LinkList<T>
    {
        Node<T> head;
        Node<T> tail;

        public LinkList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }      

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);

            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void Foreach(Action<T> action)
        {
            Node<T> n = this.head;
            while (n != null) 
            {
                action(n.Data) ;
                n = n.Next;
            }
        }

        public void PrintLinkList()
        {
            this.Foreach(n => Console.Write(n.ToString() + " "));
            Console.Write("\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkList<double> testList = new LinkList<double>();

            for (int i=0;i<10;i++)
            {
                testList.Add(i + 1);
            }

            double total = 0;
            double minData = double.MaxValue;
            double maxData = double.MinValue;
            Action<double> Method = new Action<double>(n => total += n);
            Method += (n => { if (n < minData) minData = n; });
            Method += (n => { if (n > maxData) maxData = n; });

            testList.PrintLinkList();
            testList.Foreach(Method);
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Min: {minData}");
            Console.WriteLine($"Max: {maxData}");
        }
    }
}
