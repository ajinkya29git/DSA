using System;
using System.Collections.Generic;

// Test the MinHeap class
class Program
{
    static void Main(string[] args)
    {
        MinHeap heap = new MinHeap();
        
        heap.Insert(10);
        heap.Insert(5);
        heap.Insert(20);
        heap.Insert(2);

        Console.WriteLine("Heap after inserting elements:");
        heap.PrintHeap();

        Console.WriteLine("Peek: " + heap.Peek());

        Console.WriteLine("Removed min element: " + heap.RemoveMin());
        Console.WriteLine("Heap after removing min:");
        heap.PrintHeap();
    }
}
