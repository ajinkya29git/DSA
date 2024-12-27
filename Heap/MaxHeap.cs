using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<int> heap;

    public int Size => heap.Count;

    public MaxHeap()
    {
        heap = new List<int>();
    }

    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    // Return the maximum element (root of the heap)
    public int Peek()
    {
        if (Size == 0)
            throw new InvalidOperationException("Heap is empty");

        return heap[0];
    }

    public void Insert(int value)
    {
        heap.Add(value);
        int currentIndex = heap.Count - 1;

        while (currentIndex > 0)
        {
            int parent = (currentIndex - 1) / 2;
            
            if (heap[currentIndex] <= heap[parent]) 
                break;

            Swap(currentIndex, parent);
            currentIndex = parent;
        }
    }

    public int RemoveMax()
    {
        if (Size == 0)
            throw new InvalidOperationException("Heap is empty.");

        int max = heap[0];
        heap[0] = heap[Size - 1];
        heap.RemoveAt(Size - 1);

        HeapifyDown(0);
        return max;
    }

    private void HeapifyDown(int index)
    {
        int largest = index;
        int left = 2 * index + 1;
        int right = 2 * index + 2;

        if (left < Size && heap[left] > heap[largest])
            largest = left;

        if (right < Size && heap[right] > heap[largest])
            largest = right;

        if (largest != index)
        {
            Swap(index, largest);
            HeapifyDown(largest);
        }
    }

    public void PrintHeap()
    {
        Console.WriteLine(string.Join(", ", heap));
    }
}
