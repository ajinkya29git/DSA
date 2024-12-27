using System;
using System.Collections.Generic;

class Heap
{
    static void Main(string[] args)
    {
        MinHeap minHeap = new MinHeap();
        
        minHeap.Insert(10);
        minHeap.Insert(5);
        minHeap.Insert(20);
        minHeap.Insert(8);
        minHeap.Insert(15);

        Console.WriteLine("Min Heap after inserting elements:");
        minHeap.PrintHeap();

        Console.WriteLine("Peek: " + minHeap.Peek());

        Console.WriteLine("Removed min element: " + minHeap.RemoveMin());
        Console.WriteLine("Heap after removing min:");
        minHeap.PrintHeap();

        //-------------MAX Heap-----------
        MaxHeap maxHeap = new MaxHeap();
        
        maxHeap.Insert(10);
        maxHeap.Insert(5);
        maxHeap.Insert(20);
        maxHeap.Insert(8);
        maxHeap.Insert(15);

        Console.WriteLine("Max Heap after inserting elements:");
        maxHeap.PrintHeap();

        Console.WriteLine("Peek: " + maxHeap.Peek());

        Console.WriteLine("Removed max element: " + maxHeap.RemoveMax());
        Console.WriteLine("Heap after removing max:");
        maxHeap.PrintHeap();
    }
}
