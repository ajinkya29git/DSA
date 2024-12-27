using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<int> elements = new List<int>();

    // Get the number of elements in the heap
    public int Size => elements.Count;

    // Return the minimum element (root of the heap)
    public int Peek()
    {
        if (Size == 0)
            throw new InvalidOperationException("Heap is empty");

        return elements[0];
    }

    // Move the element at index up to maintain the heap property
    private void HeapifyUp(int index)
    {
        while(index > 0)
        {
            int parentIndex = (index - 1) / 2;
            
            if (elements[index] >= elements[parentIndex])
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    // Add a new element to the heap
    public void Insert(int element)
    {
        elements.Add(element);
        HeapifyUp(Size - 1);
    }

    // Remove and return the minimum element (root of the heap)
    public int RemoveMin()
    {
        if (Size == 0)
            throw new InvalidOperationException("Heap is empty");

        int minValue = elements[0];
        elements[0] = elements[Size - 1];
        elements.RemoveAt(Size - 1);
        HeapifyDown(0);

        return minValue;
    }

    // Move the element at index down to maintain the heap property
    private void HeapifyDown(int index)
    {
        int lastIndex = Size - 1;

        while (index < lastIndex)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallerChildIndex = leftChildIndex;

            if (rightChildIndex <= lastIndex && elements[rightChildIndex] < elements[leftChildIndex])
            {
                smallerChildIndex = rightChildIndex;
            }

            if (leftChildIndex > lastIndex || elements[index] <= elements[smallerChildIndex])
                break;

            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    // Swap two elements in the heap
    private void Swap(int indexA, int indexB)
    {
        int temp = elements[indexA];
        elements[indexA] = elements[indexB];
        elements[indexB] = temp;
    }

    // Helper to display the heap content
    public void PrintHeap()
    {
        foreach (int i in elements)
        {
            Console.Write(i + " ");
        }
        
        Console.WriteLine();
    }
}