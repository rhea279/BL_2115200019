using System;
using System.Collections.Generic;
namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUsingStack<int> queue = new Queue.QueueUsingStack<int>();
            
                Console.WriteLine("\n---- Queue using Stack ----");
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                Console.WriteLine(queue.Dequeue()); 
                Console.WriteLine(queue.Peek());   
                Console.WriteLine(queue.Dequeue()); 
                Console.WriteLine(queue.Dequeue()); 
            
        }
    }
    class QueueUsingStack<T>
    {
        private Stack<T> stack1;
        private Stack<T> stack2;

        public QueueUsingStack()
        {
            stack1 = new Stack<T>();
            stack2 = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            stack1.Push(item);
        }
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is Empty");
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Peek();

        }

        public bool IsEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }

    }
}
