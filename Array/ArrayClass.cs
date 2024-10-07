using System;

class ArrayClass
{
    public static int[] MyArray {get; private set;}
    
    static ArrayClass()
    {
        MyArray = new int[5] {1,2,3,4,5};
    }

    public static void printAllSubArrays(int[] arr)
    {
        int n = arr.Length;

        for (int length = 1; length <= n; length++) // Start from length 2 to n
        {
            for (int i = 0; i <= n - length; i++)
            {
                for (int j = i; j < i + length; j++)
                { 
                    Console.Write(arr[j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }

    static void Main(string[] args)
    {
        printAllSubArrays(MyArray);
    }

}