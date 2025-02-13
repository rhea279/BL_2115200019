using System;
using System.Collections.Generic;

public class SortStack
{
    // Function to sort a stack using recursion
    public static void Sort(Stack<int> stack)
    {
        if (stack.Count > 0)
        {
            // Remove the top element
            int temp = stack.Pop();

            // Recursively sort the remaining stack
            Sort(stack);

            // Insert the popped element at the correct position
            InsertSorted(stack, temp);
        }
    }

    // Function to insert an element into a sorted stack
    private static void InsertSorted(Stack<int> stack, int element)
    {
        // If stack is empty or top element is smaller, push element
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
        }
        else
        {
            // Remove top element
            int temp = stack.Pop();

            // Recursively insert element at the correct position
            InsertSorted(stack, element);

            // Push back the stored element
            stack.Push(temp);
        }
    }

    // Helper function to print stack contents
    public static void PrintStack(Stack<int> stack)
    {
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);
        stack.Push(5);

        Console.WriteLine("Original Stack:");
        PrintStack(stack);

        Sort(stack);

        Console.WriteLine("Sorted Stack:");
        PrintStack(stack);
    }
}
